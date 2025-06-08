using KazApi.Common._Log;
using KazApi.Domain._Monster;
using UnitTest.Mock;
using Xunit.Abstractions;

namespace UnitTest.KazApi.Domain._Skill
{
    public class ISkillTest
    {
        private readonly ITestOutputHelper _output;
        private readonly ILog<BattleMetaData> _logger;
        private readonly IMonster _monster;

        public ISkillTest(ITestOutputHelper output)
        {
            _output = output;

            _logger = new BattleLogger();

            _monster = new Monster(
                MockMonsterParams.NoDodge,
                MockSkillSets.HealOnly,
                []
                );
        }

        [Fact(DisplayName = "攻撃力低下")]
        public void UT001()
        {
            var skill = MockSkills.AbsHit;
            int beforeAttack = skill.Attack;

            skill.PowerDown();

            Assert.True(skill.Attack < beforeAttack);
        }

        [Fact(DisplayName = "弱点ダメージ")]
        public void UT002()
        {
            var fire = MockSkills.AbsHitAllOrSingleTargetFire;
            var weekFireMonster = new Monster(
                MockMonsterParams.WeekFire,
                MockSkillSets.AbsHitAllAttackOnly,
                []
                );
            int beforeDamage = fire.Attack;

            int weekDamage = fire.WeeknessDamage(
                fire,
                weekFireMonster,
                fire.Attack,
                _logger);

            Assert.True(beforeDamage < weekDamage);
        }

        [Fact(DisplayName = "クリティカルダメージ")]
        public void UT003()
        {
            var critical = MockSkills.AbsHitCritical;
            int beforeDamage = critical.Attack;

            int criticalDamage = critical.CriticalDamage(
                critical,
                critical.Attack,
                _logger);

            Assert.True(beforeDamage < criticalDamage);
        }

        [Fact(DisplayName = "当たり判定")]
        public void UT004()
        {
            var halfHit = MockSkills.HalfHit;

            int hitCount = 0;
            for (int i = 0; i < 1000; i++)
                if (halfHit.IsHitSkill(halfHit, _monster)) hitCount++;

            Assert.True(hitCount >= 400);
        }
    }
}
