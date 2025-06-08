using KazApi.Common._Log;
using KazApi.Domain._Monster;
using KazApi.Domain._Monster._Skill;
using UnitTest.Mock;
using Xunit.Abstractions;

namespace UnitTest.KazApi.Domain._Skill
{
    public class DeadSkillTest
    {
        private readonly ITestOutputHelper _output;
        private readonly ILog<BattleMetaData> _logger;
        private readonly ISkill _skill;

        public DeadSkillTest(ITestOutputHelper output)
        {
            _output = output;

            _logger = new BattleLogger();

            _skill = MockSkills.DeadMagic;
        }

        [Fact(DisplayName = "HPがMAXでも効く")]
        public void UT001()
        {
            int expected = 0;
           
            for (int i = 0; i < 1000; i++)
            {
                var monster = new Monster(
                        MockMonsterParams.NoDodge,
                        MockSkillSets.AbsHitOnly,
                        []
                        );

                _skill.Use([monster], monster, _logger);
                if (monster.Hp <= 0) expected++;
            }
            Assert.True(expected < 500);
        }

        [Fact(DisplayName = "HPが低いほど効く")]
        public void UT002()
        {
            int expected = 0;
            
            for (int i = 0; i < 1000; i++)
            {
                var monster = new Monster(
                        MockMonsterParams.DyingHp,
                        MockSkillSets.AbsHitOnly,
                        []
                        );

                _skill.Use([monster], monster, _logger);
                if (monster.Hp <= 0) expected++;
            }
            Assert.True(expected > 500);
        }
    }
}
