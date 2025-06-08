using KazApi.Common._Log;
using KazApi.Domain._Monster;
using KazApi.Domain._Monster._State;
using UnitTest.Mock;
using Xunit.Abstractions;

namespace UnitTest.KazApi.Domain._State
{
    public class SlowTest
    {
        private readonly ITestOutputHelper _output;
        private readonly ILog<BattleMetaData> _logger;
        private readonly IMonster _monster;

        public SlowTest(ITestOutputHelper output)
        {
            _output = output;

            _logger = new BattleLogger();

            _monster = new Monster
                (
                    MockMonsterParams.Normal,
                    MockSkillSets.AbsHitOnly,
                    [MockStatus.SLOW]
                );
            new BattleLogger().DumpMemory(); // ログ初期化
        }

        [Fact(DisplayName = "効果(Speed: 15 >>> xx)")]
        public void UT001()
        {
            for (int i = 0; i < 100; i++)
            {
                var monster = new Monster
                (
                    MockMonsterParams.Normal,
                    MockSkillSets.AbsHitOnly,
                    [MockStatus.SLOW]
                );

                monster.StateImpact(_logger);

                Assert.True(monster.Speed == 3);;
            }
        }

        [Fact(DisplayName = "状態異常解除ログ")]
        public void UT002()
        {
            foreach (var state in _monster.CurrentStatus())
                state.DisabledLogging(_monster, _logger);

            var log = _logger.DumpMemory();

            Assert.Contains("スロー", log[0].Message);
        }

        [Fact(DisplayName = "ディープコピー")]
        public void UT003()
        {
            IState state = MockStatus.SLOW;
            IState copy = state.DeepCopy();

            Assert.True(state.Name == copy.Name);
            Assert.True(state.ShortName == copy.ShortName);
            Assert.True(state.StateType == copy.StateType);
            Assert.True(state.CancelRate == copy.CancelRate);
            Assert.False(Object.ReferenceEquals(state, copy));
        }
    }
}
