using KazApi.Common._Log;
using KazApi.Domain._Monster;
using KazApi.Domain._Monster._Skill;
using KazApi.Domain._Monster._State;
using UnitTest.Mock;
using Xunit.Abstractions;

namespace UnitTest.KazApi.Domain._Monster
{
    public class IMonsterTest
    {
        private readonly ITestOutputHelper _output;
        private readonly ILog<BattleMetaData> _logger;
        private readonly IMonster _monster;
        private readonly ISkill _healStateSkill;
        private readonly IState _healState;
        private readonly ISkill _charmStateSkill;
        private readonly IState _charmState;
        private readonly ISkill _sleepStateSkill;
        private readonly IState _sleepState;

        public IMonsterTest(ITestOutputHelper output)
        {
            _output = output;

            _logger = new BattleLogger();

            _monster = new Monster(
                    MockMonsterParams.NoDodge,
                    MockSkillSets.AbsHitOnly,
                    []);
            _healStateSkill = MockSkills.AutoHeal;
            _healState = MockStatus.AUTOHEAL;

            _charmStateSkill = MockSkills.Charm;
            _charmState = MockStatus.CHARM;

            _sleepStateSkill = MockSkills.Sleep;
            _sleepState = MockStatus.SLEEP;
        }

        [Fact(DisplayName = "状態を持つ")]
        public void UT001()
        {
            Assert.True(_monster.CurrentStatus().Count() == 0);
            
            _monster.AcceptState(_healState, _healStateSkill, _logger);

            Assert.True(_monster.CurrentStatus().Count() == 1);
        }

        [Fact(DisplayName = "状態は重複しない")]
        public void UT002_1()
        {
            Assert.True(_monster.CurrentStatus().Count() == 0);

            _monster.AcceptState(_healState, _healStateSkill, _logger);
            _monster.AcceptState(_healState, _healStateSkill, _logger);

            Assert.True(_monster.CurrentStatus().Count() == 1);
        }

        [Fact(DisplayName = "状態は複数持てる")]
        public void UT002_2()
        {
            Assert.True(_monster.CurrentStatus().Count() == 0);

            _monster.AcceptState(_healState, _healStateSkill, _logger);
            _monster.AcceptState(_charmState, _charmStateSkill, _logger);

            Assert.True(_monster.CurrentStatus().Count() == 2);
        }

        [Fact(DisplayName = "状態の解除")]
        public void UT003()
        {
            Assert.True(_monster.CurrentStatus().Count() == 0);

            _monster.AcceptState(_charmState, _charmStateSkill, _logger);
            foreach (var state in _monster.CurrentStatus())
                state.Activation();
            _monster.RefreshStatus(_logger);

            Assert.True(_monster.CurrentStatus().Count() == 0);
        }

        [Fact(DisplayName = "状態の影響")]
        public void UT004()
        {
            // 各種状態テストで実施済
        }

        [Fact(DisplayName = "行動可能か判定（可）")]
        public void UT005()
        {
            Assert.True(_monster.IsMoveAble());
        }

        [Fact(DisplayName = "行動可能か判定（不可）")]
        public void UT006()
        {
            _monster.AcceptState(_sleepState, _sleepStateSkill, _logger);

            Assert.True(!_monster.IsMoveAble());
        }

        [Fact(DisplayName = "ダメージを受ける")]
        public void UT007()
        {
            _monster.AcceptDamage(10);

            Assert.True(_monster.Hp == 90);
        }

        [Fact(DisplayName = "回復する（マイナスダメージ）")]
        public void UT008()
        {
            _monster.AcceptDamage(10);

            Assert.True(_monster.Hp == 90);
            _monster.AcceptDamage(-10);

            Assert.True(_monster.Hp == 100);
        }

        [Theory(DisplayName = "被ダメージ上限は現在のHP")]
        [InlineData(100)]
        [InlineData(99)]
        [InlineData(101)]
        [InlineData(9999)]
        public void UT009(int damage)
        {
            _monster.AcceptDamage(damage);

            Assert.True(_monster.Hp >= 0);
        }
    }
}
