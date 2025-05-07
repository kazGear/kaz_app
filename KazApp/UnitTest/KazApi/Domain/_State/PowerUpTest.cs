using KazApi.Common._Log;
using KazApi.Domain._Monster;
using KazApi.Domain._Monster._State;
using Microsoft.CodeAnalysis.CSharp;
using UnitTest.Mock;
using Xunit.Abstractions;

namespace UnitTest.KazApi.Domain._State
{
    public class PowerUpTest
    {
        private readonly ITestOutputHelper _output;
        private readonly IMonster _monster;

        public PowerUpTest(ITestOutputHelper output)
        {
            _output = output;
            _monster = new Monster
                (
                    MockMonsterParams.Normal,
                    MockSkillSets.AbsHitOnly,
                    [MockStatus.POWERUP]
                );
            new BattleLogger().DumpMemory(); // ログ初期化
        }

        [Fact(DisplayName = "効果(Attack: 20 >>> xx)")]
        public void UT001()
        {
            for (int i = 0; i < 100; i++)
            {
                var monster = new Monster
                (
                    MockMonsterParams.Normal,
                    MockSkillSets.AbsHitOnly,
                    [MockStatus.POWERUP]
                );

                monster.StateImpact();

                Assert.True(monster.Attack == 35);
            }
        }

        [Fact(DisplayName = "状態異常解除ログ")]
        public void UT002()
        {
            foreach (var state in _monster.CurrentStatus())
                state.DisabledLogging(_monster);

            var logger = new BattleLogger();
            var log = logger.DumpMemory();

            Assert.Contains("攻撃力", log[0].Message);
        }

        [Fact(DisplayName = "ディープコピー")]
        public void UT003()
        {
            IState state = MockStatus.POWERUP;
            IState copy = state.DeepCopy();

            Assert.True(state.Name == copy.Name);
            Assert.True(state.ShortName == copy.ShortName);
            Assert.True(state.StateType == copy.StateType);
            Assert.True(state.CancelRate == copy.CancelRate);
            Assert.False(Object.ReferenceEquals(state, copy));
        }
    }
}
