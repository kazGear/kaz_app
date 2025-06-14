using KazApi.Common._Log;
using KazApi.Domain._Const;
using KazApi.Domain._Monster;
using KazApi.Domain._Monster._State;
using UnitTest.Mock;
using Xunit.Abstractions;

namespace UnitTest.KazApi.Domain._State
{
    public class SleepTest
    {
        private readonly ITestOutputHelper _output;
        private readonly ILog<BattleMetaData> _logger;
        private readonly IMonster _monster;
        private readonly IMonster _monster2;

        public SleepTest(ITestOutputHelper output)
        {
            _output = output;

            _logger = new BattleLogger();

            _monster = new Monster
                (
                    MockMonsterParams.Normal,
                    MockSkillSets.AbsHitOnly,
                    [new Sleep("睡眠", "眠", CStateType.SLEEP.Value, 0.0)]
                );
            _monster2 = new Monster
                (
                    MockMonsterParams.Normal,
                    MockSkillSets.AbsHitOnly,
                    []
                );
            new BattleLogger().DumpMemory(); // ログ初期化
        }

        [Fact(DisplayName = "効果（行動不可）")]
        public void UT001()
        {
            for (int i = 0; i < 100; i++)
            {
                IList<IMonster> monsters =
                    [
                        _monster, _monster2
                    ];
                
                if (monsters[0].IsMoveAble()) monsters[0].Move(monsters, _logger);

                Assert.True(monsters[1].Hp == 100);
            }
        }

        [Fact(DisplayName = "睡眠メッセージ")]
        public void UT001_2()
        {
            IList<IMonster> monsters =
                [
                    _monster, _monster2
                ];

            monsters[0].StateImpact(_logger);
            var log = _logger.DumpMemory();

            Assert.Contains("眠っている", log[0].Message);
        }

        [Fact(DisplayName = "状態異常解除ログ")]
        public void UT002()
        {
            foreach (var state in _monster.CurrentStatus())
                state.DisabledLogging(_monster, _logger);

            var log = _logger.DumpMemory();

            Assert.Contains("目覚めた", log[0].Message);
        }

        [Fact(DisplayName = "ディープコピー")]
        public void UT003()
        {
            IState state = MockStatus.SLEEP;
            IState copy = state.DeepCopy();

            Assert.True(state.Name == copy.Name);
            Assert.True(state.ShortName == copy.ShortName);
            Assert.True(state.StateType == copy.StateType);
            Assert.True(state.CancelRate == copy.CancelRate);
            Assert.False(Object.ReferenceEquals(state, copy));
        }
    }
}
