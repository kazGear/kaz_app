using CSLib.Lib;
using KazApi.Domain._Const;
using KazApi.Domain._Factory;
using KazApi.Domain._GameSystem;
using KazApi.Domain._Monster._State;
using KazApi.Domain._Monster;
using KazApi.Domain.DTO;
using System.Text;
using KazApi.Service;

namespace TestRun
{
    internal class MonsterBattle
    {
        private BattleService _service = new BattleService();
        private MonsterFactory _monsterFactory = new MonsterFactory();
        private URandom _random = new URandom();

        internal void Run()
        {
            try
            {
                Console.OutputEncoding = Encoding.UTF8;

                /**
                 * モンスタ－用意
                 */

                // モンスターデータ等の読込み
                IEnumerable<MonsterDTO> monstersFromDB = _service.SelectMonsters("admin");
                IEnumerable<SkillDTO> skillsFromDB = _service.SelectSkills();
                IEnumerable<MonsterSkillDTO> monsterSkillFromDB = _service.SelectMonsterSkills();

                // モンスターDTO構築
                IEnumerable<MonsterDTO> monstersDTO =
                    _monsterFactory.MappingToMonsterDTO(monstersFromDB, skillsFromDB, monsterSkillFromDB);

                // 参加モンスター（モンスター数はランダム）
                IEnumerable<MonsterDTO> battleMonstersDTO
                    = BattleSystem.MonsterSelector(monstersDTO, _random.RandomInt(2, 7));

                // 任意のテストモンスター
                battleMonstersDTO = UseTestMonsters(monstersDTO);


                // 戦闘用モンスターを構築
                IEnumerable<CodeDTO> stateCodeFromDB = _service.SelectStateCode();
                IEnumerable<IMonster> battleMonsters
                    = _monsterFactory.CreateBattleMonsters(battleMonstersDTO, stateCodeFromDB);

                // TODO 未実装 チーム決め
                ((List<IMonster>)battleMonsters).ForEach(e => e.DefineTeam(CTeam.A.VALUE));

                if (battleMonsters.Where(e => e.Team == (CTeam.UNKNOWN.VALUE)).Count() > 0)
                {
                    throw new Exception("チーム決めが完了していません。");
                }

                IEnumerable<IMonster> alives = []; // 生き残りモンスター

                /**
                 * 戦闘不能が1人以下になるまで戦う
                 */
                int turnCounter = 1;
                
                do
                {
                    // 行動順決め
                    IEnumerable<IMonster> orderedMonsters = BattleSystem.ActionOrder(battleMonsters);

                    // モンスタ達のーの行動
                    foreach (IMonster me in orderedMonsters)
                    {
                        // 行動不可
                        if (me.Hp <= 0) continue;

                        // 状態異常の効果
                        me.StateImpact();

                        // モンスターの行動
                        IList<IMonster> otherMonsters = orderedMonsters.Where(e => e.MonsterId != me.MonsterId).ToList();
                        if (me.IsMoveAble()) me.Move(otherMonsters);

                        // 状態異常解除
                        IEnumerable<IState> currentStatus = me.CurrentStatus();
                        ISet<IState> changedStatus = new HashSet<IState>();
                        foreach (IState state in currentStatus)
                        {
                            if (!BattleSystem.StateIsDisabled(state))
                                changedStatus.Add(state);
                            else
                                state.DisabledLogging(me);
                        }
                        me.UpdateStatus(changedStatus);

                        // HP 現状確認
                        foreach (IMonster monster in battleMonsters)
                        {
                            int hp = monster.Hp > 0 ? monster.Hp : 0;
                        }

                        // 勝敗判定
                        alives = battleMonsters.Where(e => e.Hp > 0);
                        IMonster? alive = alives.Count() == 1 ? alives.Single() : null;

                    }

                    /**************************************************
                     * 状態等の確認
                     **************************************************/
                    PrintStatus(battleMonsters);
                    PrintGuide(turnCounter);
                    turnCounter++;

                } while (alives.Count() > 1);
            }
            catch (Exception e)
            {
                Console.WriteLine("test run が異常終了しました。");
                Console.WriteLine(e);
            }
        }

        private void PrintGuide(int turnCounter)
        {
            Console.WriteLine($">>> {turnCounter}ターン目終了。キー押下（何でもOK）で次のターンへ。\n");
            Console.ReadLine();
        }

        private void PrintStatus(IEnumerable<IMonster> monsters)
        {
            foreach (IMonster m in monsters)
            {
                string status = string.Empty;
                foreach (IState s in m.CurrentStatus()) status += $"{s.Name }";

                Console.WriteLine(
                    $"{m.MonsterName} > hp: {m.Hp}, status: {status}"
                );
            }
        }

        private IEnumerable<MonsterDTO> UseTestMonsters(IEnumerable<MonsterDTO> monstersDTO)
        {
            IEnumerable<MonsterDTO> testMonsters = new List<MonsterDTO>()
            {
                //monstersDTO.Where(e => e.MonsterId == CMonster.カーミラクイーン.VALUE).Single(),
                //monstersDTO.Where(e => e.MonsterId == CMonster.マーマポト.VALUE).Single(),
                //monstersDTO.Where(e => e.MonsterId == CMonster.パーパポト.VALUE).Single(),
                //monstersDTO.Where(e => e.MonsterId == CMonster.カーミラ.VALUE).Single(),
                //monstersDTO.Where(e => e.MonsterId == CMonster.キラービー.VALUE).Single(),
                //monstersDTO.Where(e => e.MonsterId == CMonster.アサシンバグ.VALUE).Single(),
                //monstersDTO.Where(e => e.MonsterId == CMonster.ラスターバグ.VALUE).Single(),
                //monstersDTO.Where(e => e.MonsterId == CMonster.イビルウェポン.VALUE).Single(),
                //monstersDTO.Where(e => e.MonsterId == CMonster.クロウラー.VALUE).Single(),
                //monstersDTO.Where(e => e.MonsterId == CMonster.ダースマタンゴ.VALUE).Single(),
                //monstersDTO.Where(e => e.MonsterId == CMonster.ゴブリン.VALUE).Single(),
                //monstersDTO.Where(e => e.MonsterId == CMonster.ゴブリンガード.VALUE).Single(),
                //monstersDTO.Where(e => e.MonsterId == CMonster.ゴブリンロード.VALUE).Single(),
                //monstersDTO.Where(e => e.MonsterId == CMonster.サハギン.VALUE).Single(),
                //monstersDTO.Where(e => e.MonsterId == CMonster.プチポセイドン.VALUE).Single(),
                //monstersDTO.Where(e => e.MonsterId == CMonster.パンプキンボム.VALUE).Single(),
                //monstersDTO.Where(e => e.MonsterId == CMonster.グレネードボム.VALUE).Single(),
                monstersDTO.Where(e => e.MonsterId == CMonster.シェイプシフター.VALUE).Single(),
                monstersDTO.Where(e => e.MonsterId == CMonster.シャドウゼロ.VALUE).Single(),
                monstersDTO.Where(e => e.MonsterId == CMonster.シャドウゼロワン.VALUE).Single(),
            };
            return testMonsters;
        }
    }
}
