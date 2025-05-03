using KazApi.Common._Log;
using KazApi.Domain._Monster;
using KazApi.Domain._Monster._State;
using UnitTest.Mock;
using Xunit.Abstractions;

namespace UnitTest.KazApi.Domain._State
{
    public class CharmTest
    {
        private readonly ITestOutputHelper _output;
        private readonly IMonster _monster;

        public CharmTest(ITestOutputHelper output)
        {
            _output = output;
            _monster = new Monster( // 必ず自傷ダメージが当たる設定
                MockMonsterParams.NoDodgeParam,
                MockSkillSets.FireOnly,
                [MockStatus.CHARM]
                );

            new BattleLogger().DumpMemory(); // ログ初期化
        }

        [Fact(DisplayName = "効果（自傷ダメージ）")]
        public void UT001()
        {
            int savedHp = _monster.Hp;

            _monster.StateImpact();

            Assert.True(_monster.Hp < savedHp);
        }

        [Fact(DisplayName = "睡眠時は効果なし")]
        public void UT002()
        {
            _monster.UpdateStatus(new HashSet<IState>()
                {
                    MockStatus.CHARM,
                    MockStatus.SLEEP,
                });
            int savedHp = _monster.Hp;

            _monster.StateImpact();

            Assert.True(_monster.Hp == savedHp);
        }

        [Fact(DisplayName = "状態異常解除ログ")]
        public void UT003()
        {
            foreach (var state in _monster.CurrentStatus())
                state.DisabledLogging(_monster);

            var logger = new BattleLogger();
            var log = logger.DumpMemory();

            Assert.Contains("我に返った", log[0].Message);
        }

        [Fact(DisplayName = "ディープコピー")]
        public void UT004()
        {
            IState state = MockStatus.CHARM;
            IState copy = state.DeepCopy();

            Assert.True(state.Name == copy.Name);
            Assert.True(state.ShortName == copy.ShortName);
            Assert.True(state.StateType == copy.StateType);
            Assert.True(state.CancelRate == copy.CancelRate);
            Assert.False(Object.ReferenceEquals(state, copy));
        }
    }
}
