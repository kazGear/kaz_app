using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using KazApi.Controller.Service;
using KazApi.Domain.DTO;
using System.Transactions;

namespace KazApi.Controller
{
    [ApiController]
    public class EditController : ControllerBase
    {
        private readonly EditService _service;

        public EditController(IConfiguration configuration)
        {
            _service = new EditService(configuration);
        }

        /// <summary>
        /// 初期処理
        /// </summary>
        [HttpPost("api/edit/init")]
        public ActionResult<string> Init()
        {
            // ドロップダウンの選択肢を取得
            IEnumerable<CodeDTO> dropDown = _service.FetchDropDown();
            return JsonConvert.SerializeObject(dropDown);
        }

        [HttpPost("api/edit/fetchMonsters")]
        public ActionResult<string> FetctEditMonsters([FromQuery] string loginId)
        {
            IEnumerable<EditMonsterDTO> monsters = _service.FetchEditMonsters(loginId);
            return JsonConvert.SerializeObject(monsters);
        }

        /// <summary>
        /// モンスターのステータスを設定する
        /// </summary>
        [HttpPost("api/edit/updateMonsterStatus")]
        public ActionResult UpdateMonsterStatus([FromBody] IEnumerable<EditMonsterDTO> monsters)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                try
                {
                    IEnumerable<EditMonsterDTO> changeMonsters
                        = monsters.Where(e => e.IsChanged == true);

                    // 未設定値はデフォルト値とする
                    foreach (EditMonsterDTO monster in changeMonsters)
                    {
                        if (monster.AfterName   == null) monster.AfterName = monster.MonsterName;
                        if (monster.AfterHp     == null) monster.AfterHp = monster.Hp;
                        if (monster.AfterAttack == null) monster.AfterAttack = monster.Attack;
                        if (monster.AfterSpeed  == null) monster.AfterSpeed = monster.Speed;
                        if (monster.AfterWeek   == null) monster.AfterWeek = monster.Week;
                    }
                    _service.UpdateMonsterStatus(changeMonsters);

                    transaction.Complete();
                }
                catch (Exception)
                {
                    return StatusCode(500, "モンスターステータスの更新に失敗しました。");
                }
            }
            return Ok(200);
        }
    }
}
