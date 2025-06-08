using KazApi.Common._Log;
using KazApi.Domain._Const;
using KazApi.Domain._Monster;
using KazApi.Domain._Monster._Skill;
using Microsoft.CodeAnalysis.Host.Mef;
using UnitTest.Mock;
using Xunit.Abstractions;

namespace UnitTest.KazApi.Domain._Skill
{
    public class HealSkillTest
    {
        private readonly ITestOutputHelper _output;
        private readonly ILog<BattleMetaData> _logger;
        private readonly IMonster _monster;
        private readonly ISkill _skill;

        public HealSkillTest(ITestOutputHelper output)
        {
            _output = output;

            _logger = new BattleLogger();

            _monster = new Monster(
                MockMonsterParams.Normal,
                MockSkillSets.HealOnly,
                []
                );
            _skill = MockSkills.HealMagic;
        }

        [Fact(DisplayName = "HP回復")]
        public void UT001()
        {
            _monster.AcceptDamage(99);
            Assert.True(_monster.Hp <= 1);

            _skill.Use([_monster], _monster, _logger);

            Assert.True(_monster.Hp > 1);
        }

        [Fact(DisplayName = "回復上限はMaxHp")]
        public void UT002()
        {
            _monster.AcceptDamage(1);
            Assert.True(_monster.Hp == 99);
            Assert.True(_monster.MaxHp == 100);

            _skill.Use([_monster], _monster, _logger);

            Assert.True(_monster.Hp == 100);
        }
    }
}
