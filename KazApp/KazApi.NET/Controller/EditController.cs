using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using KazApi.Controller.Service;
using KazApi.Repository;
using KazApi.Domain.DTO;

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
            IEnumerable<MonsterDTO> monsters = _service.FetchEditMonsters(loginId);
            return JsonConvert.SerializeObject(monsters);
        }
    }
}
