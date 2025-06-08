using KazApi.Common._Log;
using KazApi.Domain._Monster;
using KazApi.Domain._Monster._Skill;
using Microsoft.CodeAnalysis.Host.Mef;
using UnitTest.Mock;
using Xunit.Abstractions;

namespace UnitTest.KazApi.Domain._Skill
{
    public class IMonsterTest
    {
        private readonly ITestOutputHelper _output;
        private readonly ILog<BattleMetaData> _logger;
        private IList<IMonster> _monsters;
        private IMonster _monster;

        public IMonsterTest(ITestOutputHelper output)
        {
            _output = output;

            _logger = new BattleLogger();

            _monster = new Monster(
                    MockMonsterParams.NoDodge,
                    MockSkillSets.AbsHitOnly,
                    []);
            _monsters = new List<IMonster>()
            {
                new Monster(
                    MockMonsterParams.NoDodge,
                    MockSkillSets.AbsHitOnly,
                    []),
                new Monster(
                    MockMonsterParams.NoDodge,
                    MockSkillSets.AbsHitOnly,
                    []),
            };
        }

        [Fact(DisplayName = "単体攻撃")]
        public void UT001()
        {
            MockSkills.AbsHit.Use(_monsters, _monster, _logger);

            int damageCount = 0;
            foreach (var monster in _monsters)
                if (monster.Hp < monster.MaxHp) damageCount++;

            Assert.True(damageCount == 1);
        }

        [Fact(DisplayName = "全体攻撃")]
        public void UT002()
        {
            MockSkills.AbsHitAllTarget.Use(_monsters, _monster, _logger);

            int damageCount = 0;
            foreach (var monster in _monsters)
                if (monster.Hp < monster.MaxHp) damageCount++;

            Assert.True(damageCount == 2);
        }

        [Fact(DisplayName = "無効なターゲット")]
        public void UT003()
        {
            try
            {
                MockSkills.InvalidTarget.Use(_monsters, _monster, _logger);
                Assert.Fail();
            }
            catch { }
        }

        [Fact(DisplayName = "単体 or 全体攻撃")]
        public void UT004()
        {
            int singleTarget = 0;
            int allTarget = 0;
            int damageCount = 0;

            for (int i = 0; i < 1000; i++)
            {
                _monsters = new List<IMonster>()
                {
                new Monster(
                    MockMonsterParams.NoDodge,
                    MockSkillSets.AbsHitOnly,
                    []),
                new Monster(
                    MockMonsterParams.NoDodge,
                    MockSkillSets.AbsHitOnly,
                    []),
                };
                MockSkills.AbsHitAllOrSingleTargetFire.Use(_monsters, _monster, _logger);
                damageCount = _monsters.Where(e => e.Hp < e.MaxHp).Count();

                if (damageCount == 1) singleTarget++;
                else if (damageCount == 2) allTarget++;
            }

            Assert.True(singleTarget >= 35);
            Assert.True(allTarget >= 35);
        }

        [Fact(DisplayName = "全体攻撃の威力減衰")]
        public void UT005()
        {
            int expectCount = 0;
            for (int i = 0; i < 1000; i++)
            {
                IList<IMonster> acceptSingleDamageMonster = new List<IMonster>()
                {
                    new Monster(MockMonsterParams.NoDodge, MockSkillSets.AbsHitOnly, [])
                };
                IList<IMonster> acceptAllDamageMonster = new List<IMonster>()
                {
                    new Monster(MockMonsterParams.NoDodge, MockSkillSets.AbsHitOnly, [])
                };

                MockSkills.AbsHit.Use(acceptSingleDamageMonster, acceptAllDamageMonster[0], _logger);
                MockSkills.AbsHitAllTarget.Use(acceptAllDamageMonster, acceptSingleDamageMonster[0], _logger);

                // 単体攻撃の方がダメージが大きい
                if (acceptSingleDamageMonster[0].Hp <= acceptAllDamageMonster[0].Hp)
                    expectCount++;
            }
            Assert.True(expectCount >= 80); // 概ね想定通りなはず
        }

        [Fact(DisplayName = "被ダメのランダム補正")]
        public void UT006()
        {
            int beforeHp = 0;
            int sameCount = 0;
            for (int i = 0; i < 1000; i++)
            {
                var monsters = new List<IMonster>()
                {
                    new Monster(
                        MockMonsterParams.NoDodge,
                        MockSkillSets.AbsHitOnly,
                        [])
                };

                MockSkills.AbsHit.Use(monsters, monsters[0], _logger);

                if (beforeHp != monsters[0].Hp)
                    sameCount = 0;
                else
                    sameCount++;

                if (sameCount >= 10) Assert.Fail(); // ダメージは基本敵にバラバラなはず
                beforeHp = monsters[0].Hp;
            }
        }

        [Fact(DisplayName = "属性ダメージ補正")]
        public void UT007()
        {
            for (int i = 0; i < 1000; i++)
            {
                var weekFireMonsters = new List<IMonster>()
                {
                    new Monster(
                        MockMonsterParams.WeekFire,
                        MockSkillSets.HealOnly,
                        [])
                };
                var normalMonsters = new List<IMonster>()
                { 
                    new Monster(
                        MockMonsterParams.NoDodge,
                        MockSkillSets.HealOnly,
                        [])
                };
                MockSkills.FireSingleTargetMagic.Use(weekFireMonsters, normalMonsters[0], _logger);
                MockSkills.IceSingleTarget.Use(normalMonsters, weekFireMonsters[0], _logger);

                Assert.True(weekFireMonsters[0].Hp < normalMonsters[0].Hp);
            }
        }

        [Fact(DisplayName = "クリティカルダメージ補正")]
        public void UT008()
        {
            int expectCount = 0;
            for (int i = 0; i < 1000; i++)
            {
                var acceptCriticalMonsters = new List<IMonster>()
                {
                    new Monster(
                        MockMonsterParams.WeekFire,
                        MockSkillSets.HealOnly,
                        [])
                };
                var normalMonsters = new List<IMonster>()
                {
                    new Monster(
                        MockMonsterParams.NoDodge,
                        MockSkillSets.HealOnly,
                        [])
                };
                
                MockSkills.AbsHitCritical.Use(acceptCriticalMonsters, normalMonsters[0], _logger); ;
                MockSkills.AbsHit.Use(normalMonsters, acceptCriticalMonsters[0], _logger);

                if (acceptCriticalMonsters[0].Hp <= normalMonsters[0].Hp)
                    expectCount++;
            }
            Assert.True(expectCount >= 80); // 概ね想定通りのはず
        }
    }
}
