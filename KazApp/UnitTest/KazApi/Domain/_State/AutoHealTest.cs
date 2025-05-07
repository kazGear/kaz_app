using KazApi.Common._Log;
using KazApi.Domain._Monster;
using KazApi.Domain._Monster._State;
using UnitTest.Mock;
using Xunit.Abstractions;

namespace UnitTest.KazApi.Domain._State
{
    public class AutoHealTest
    {
        private readonly ITestOutputHelper _output;
        private readonly IMonster _monster;

        public AutoHealTest(ITestOutputHelper output)
        {
            _output = output;
            _monster = new Monster
                (
                    MockMonsterParams.Normal,
                    MockSkillSets.AbsHitOnly,
                    [MockStatus.AUTOHEAL]
                );

            new BattleLogger().DumpMemory();
        }

        [Fact(DisplayName = "効果(Hp: 50 >>> xx)")]
        public void UT001()
        {
            for (int i = 0; i < 100; i++)
            {
                var monster = new Monster
                (
                    MockMonsterParams.Normal,
                    MockSkillSets.AbsHitOnly,
                    [MockStatus.AUTOHEAL]
                );
                monster.AcceptDamage((int)(_monster.Hp * 0.5));

                monster.StateImpact();

                Assert.True(61 <= monster.Hp && monster.Hp <= 68);
            }
        }

        [Fact(DisplayName = "回復上限")]
        public void UT002()
        {
            _monster.AcceptDamage(1);

            _monster.StateImpact();

            Assert.True(_monster.Hp == _monster.MaxHp);
        }

        [Fact(DisplayName = "状態異常解除ログ")]
        public void UT003()
        {
            foreach (var state in _monster.CurrentStatus())
                state.DisabledLogging(_monster);

            var logger = new BattleLogger();
            var log = logger.DumpMemory();

            Assert.Contains("自然治癒力", log[0].Message);
        }

        [Fact(DisplayName = "ディープコピー")]
        public void UT004()
        {
            IState state = MockStatus.AUTOHEAL;
            IState copy = state.DeepCopy();

            Assert.True(state.Name == copy.Name);
            Assert.True(state.ShortName == copy.ShortName);
            Assert.True(state.StateType == copy.StateType);
            Assert.True(state.CancelRate == copy.CancelRate);
            Assert.False(Object.ReferenceEquals(state, copy));
        }
    }
}
