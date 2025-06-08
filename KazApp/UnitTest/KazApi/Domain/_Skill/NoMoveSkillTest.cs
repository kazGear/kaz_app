using KazApi.Common._Log;
using KazApi.Domain._Monster;
using KazApi.Domain._Monster._Skill;
using UnitTest.Mock;
using Xunit.Abstractions;

namespace UnitTest.KazApi.Domain._Skill
{
    public class NoMoveSkillTest
    {
        private readonly ITestOutputHelper _output;
        private readonly ILog<BattleMetaData> _logger;
        private readonly IMonster _monster;
        private readonly ISkill _skill;

        public NoMoveSkillTest(ITestOutputHelper output)
        {
            _output = output;

            _logger = new BattleLogger();

            _monster = new Monster(
                MockMonsterParams.Normal,
                MockSkillSets.HealOnly,
                []
                );
            _skill = MockSkills.NoMove055;
        }

        [Fact(DisplayName = "パラメータの影響なし")]
        public void UT001()
        {
            var beforeHp = _monster.Hp;
            var beforeAttack = _monster.Attack;
            var beforeSpeed = _monster.Speed;
            var beforeDodge = _monster.Dodge;

            _skill.Use([_monster], _monster, _logger);

            Assert.True(beforeHp == _monster.Hp);
            Assert.True(beforeAttack == _monster.Attack);
            Assert.True(beforeSpeed == _monster.Speed);
            Assert.True(beforeDodge == _monster.Dodge);
        }

        [Fact(DisplayName = "状態が増えない")]
        public void UT002()
        {
            _skill.Use([_monster], _monster, _logger);

            Assert.True(_monster.CurrentStatus().Count() == 0);
        }

        [Fact(DisplayName = "状態が減らない")]
        public void UT003()
        {
            var monster = new Monster(
                MockMonsterParams.Normal,
                MockSkillSets.HealOnly,
                [
                    MockStatus.POISON,
                    MockStatus.SLEEP,
                    MockStatus.CHARM
                ]);

            _skill.Use([monster], monster, _logger);

            Assert.True(monster.CurrentStatus().Count() == 3);
        }
    }
}
