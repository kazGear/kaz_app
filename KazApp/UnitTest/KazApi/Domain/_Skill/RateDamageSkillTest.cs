using KazApi.Domain._Const;
using KazApi.Domain._Monster;
using KazApi.Domain._Monster._Skill;
using KazApi.Domain._Monster._State;
using Microsoft.CodeAnalysis.Host.Mef;
using UnitTest.Mock;
using Xunit.Abstractions;

namespace UnitTest.KazApi.Domain._Skill
{
    public class RateDamageSkillTest
    {
        private readonly ITestOutputHelper _output;
        private readonly IMonster _monster;
        private readonly ISkill _skill;

        public RateDamageSkillTest(ITestOutputHelper output)
        {
            _output = output;
            _monster = new Monster(
                MockMonsterParams.Normal,
                MockSkillSets.HealOnly,
                []
                );
            _skill = MockSkills.RateDamage;
        }

        [Fact(DisplayName = "割合ダメージ（偶数HP）")]
        public void UT001()
        {
            Assert.True(_monster.Hp == 100);
            
            _skill.Use([_monster], _monster);
           
            Assert.True(_monster.Hp == 50);
        }

        [Fact(DisplayName = "割合ダメージ（奇数HP）")]
        public void UT002()
        {
            _monster.AcceptDamage(1);
            Assert.True(_monster.Hp == 99);
            
            _skill.Use([_monster], _monster);

            Assert.True(_monster.Hp == 50);
        }

        [Fact(DisplayName = "HP１から戦闘不能にはならない")]
        public void UT003()
        {
            _monster.AcceptDamage(99);
            Assert.True(_monster.Hp == 1);

            _skill.Use([_monster], _monster);

            Assert.True(_monster.Hp == 1);
        }

        [Fact(DisplayName = "現HPに対して割合ダメージを与える")]
        public void UT004()
        {
            _monster.AcceptDamage(50);
            Assert.True(_monster.Hp == 50);

            _skill.Use([_monster], _monster);

            Assert.True(_monster.Hp == 25);
        }
    }
}
