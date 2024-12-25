using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using KazApi.Common._Log;
using KazApi.Domain._ViewModel;
using KazApi.Controller.Service;
using KazApi.Domain._Factory;
using KazApi.Domain._GameSystem;
using KazApi.Domain._Monster;
using KazApi.Domain._Const;
using KazApi.Domain.DTO;
using Microsoft.CodeAnalysis;
using System.Transactions;

namespace KazApi.Controller
{
    [ApiController]
    public class BattleController : ControllerBase
    {
        private readonly ILog<BattleMetaData> _logger;
        private readonly BattleService _service;
        private readonly ShopService _shopService;
        private readonly MonsterFactory _monsterFactory;

        public BattleController(IConfiguration configuration)
        {
            _logger = new BattleLogger();
            _service = new BattleService(configuration);
            _shopService = new ShopService(configuration);
            _monsterFactory = new MonsterFactory();
        }

        /// <summary>
        /// モンスター情報
        /// </summary>
        [HttpPost("api/battle/monstersInfo")]
        public ActionResult<string> MonstersInfo(string loginId)
        {
            try
            {
                IEnumerable<MonsterDTO> monsters = _service.SelectMonsters(loginId);
                return JsonConvert.SerializeObject(monsters);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        /// <summary>
        /// 初期処理
        /// </summary>
        [HttpPost("api/battle/init")]
        public ActionResult<string> Init([FromQuery] int selectMonstersCount, [FromQuery] string loginId)
        {
            try
            {
                // モンスターデータ等の読込み
                IEnumerable<MonsterDTO> monstersFromDB = _service.SelectMonsters(loginId);
                IEnumerable<SkillDTO> skillsFromDB = _service.SelectSkills();
                IEnumerable<MonsterSkillDTO> monsterSkillFromDB = _service.SelectMonsterSkills();

                // モンスターDTO構築
                IEnumerable<MonsterDTO> monstersDTO =
                    _monsterFactory.MappingToMonsterDTO(monstersFromDB, skillsFromDB, monsterSkillFromDB);

                // 参加モンスター（ランダム）
                IEnumerable<MonsterDTO> battleMonsters
                    = BattleSystem.MonsterSelector(monstersDTO, selectMonstersCount);

                // 賭けレート算出
                BattleSystem.CalcBetRate(battleMonsters);

                // テスト用モンスターで対戦
                //battleMonsters = UseTestMonsters(monstersDTO);

                return JsonConvert.SerializeObject(battleMonsters); ;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        /// <summary>
        /// テストしたいモンスターを指定する
        /// </summary>
        /// <param name="monstersDTO"></param>
        /// <returns></returns>
        private IEnumerable<MonsterDTO> UseTestMonsters(IEnumerable<MonsterDTO> monstersDTO)
        {
            IEnumerable<MonsterDTO> testMonsters = new List<MonsterDTO>()
            {
                monstersDTO.Where(e => e.MonsterId == CMonster.キラービー.VALUE).Single(),
                monstersDTO.Where(e => e.MonsterId == CMonster.アサシンバグ.VALUE).Single(),
                monstersDTO.Where(e => e.MonsterId == CMonster.ラスターバグ.VALUE).Single(),
                monstersDTO.Where(e => e.MonsterId == CMonster.カーミラクイーン.VALUE).Single(),
                monstersDTO.Where(e => e.MonsterId == CMonster.カーミラクイーン.VALUE).Single(),
            };
            return testMonsters;
        }

        /// <summary>
        /// モンスターたちの行動
        /// </summary>
        [HttpPost("api/battle/nextTurn")]
        public ActionResult<string> NextTurn([FromBody] IEnumerable<MonsterDTO> monsters)
        {
            // 戦闘用モンスターを構築
            IEnumerable<CodeDTO> codes = _service.SelectStateCode();
            IEnumerable<IMonster> battleMonsters = _monsterFactory.CreateBattleMonsters(monsters, codes);

            // TODO 未実装 チーム決め
            ((List<IMonster>)battleMonsters).ForEach(e => e.DefineTeam(CTeam.A.VALUE));
            if (battleMonsters.Where(e => e.Team == CTeam.UNKNOWN.VALUE).Count() > 0)
            {
                throw new Exception("チーム決めが完了していません。");
            }
            // 行動順決め
            IEnumerable<IMonster> orderedMonsters = BattleSystem.ActionOrder(battleMonsters);

            // モンスターの行動
            foreach (IMonster me in orderedMonsters)
            {
                if (me.Hp <= 0) continue;

                // 誰のターンか
                MessageInfo.WhoseTurn(me);
               
                // 状態異常の影響
                me.StateImpact();

                // モンスターの行動
                IList<IMonster> otherMonsters = orderedMonsters.Where(e => e.MonsterId != me.MonsterId).ToList();
                if (me.IsMoveAble())
                    me.Move(otherMonsters);

                // 状態異常解除
                BattleSystem.DisabledStatus(me);
            }

            // 勝敗判定
            MessageInfo.BattleResult(battleMonsters);

            // DTOへ変換
            IEnumerable<MonsterDTO> monstersDTO = _monsterFactory.ConvertToDTO(battleMonsters);

            BattleViewModel model = new BattleViewModel();
            _logger.Logging(new BattleMetaData());
            model.Monsters = monstersDTO;
            model.BattleLog = _logger.DumpMemory();

            if (model.Monsters.Count() <= 0) 
                Console.WriteLine("monsters がゼロ");
            if (model.BattleLog.Count() <= 0) 
                Console.WriteLine("battleLog がゼロ");

            return JsonConvert.SerializeObject(model);
        }

        /// <summary>
        /// 勝敗結果を記録（モンスター）
        /// </summary>
        [HttpPost("api/battle/recordResults")]
        public ActionResult<bool> RecordResults([FromBody] IEnumerable<MonsterDTO> monsters)
        {
            DateTime endDate = DateTime.Now;
            TimeSpan endTime = new TimeSpan(endDate.Ticks);

            return _service.InsertBattleResult(monsters, endDate, endTime);
        }

        /// <summary>
        /// 勝敗結果を記録（ユーザー）
        /// ショップ開放の確認
        /// </summary>
        [HttpPost("api/user/recordUserResults")]
        public ActionResult<string> RecordUserResults(
            [FromQuery] string betMonsterId,
            [FromQuery] int betGil,
            [FromQuery] decimal betRate,
            [FromQuery] string winningMonsterId,
            [FromQuery] string loginId)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                try
                {
                    if (string.IsNullOrEmpty(winningMonsterId))
                        return Ok(new { message = "No action required." });

                    // クレンジング
                    loginId = loginId.Trim();
                    betMonsterId = betMonsterId.Trim();
                    winningMonsterId = winningMonsterId.Trim();

                    // 予想的中か
                    bool hit = false;
                    if (betMonsterId == winningMonsterId) hit = true;

                    // 各種登録
                    _service.UpdateUserResults(hit, betGil, betRate, loginId);

                    IEnumerable<ShopDTO> InsertUsableShop = _shopService.ExistsUsableShop(loginId);
                    if (InsertUsableShop.Count() > 0)
                    {
                        _shopService.InsertUsableShop(loginId, InsertUsableShop);
                    }

                    // 処理完了
                    transaction.Complete();
                    return JsonConvert.SerializeObject(InsertUsableShop);
                }
                catch (Exception)
                {
                    return StatusCode(500, $"Error resist user result.");
                }
            }
        }
    }
}
