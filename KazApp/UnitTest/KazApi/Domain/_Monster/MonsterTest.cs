using KazApi.Common._Log;
using KazApi.Domain._Monster;
using KazApi.Domain._Monster._Skill;
using UnitTest.Mock;
using Xunit.Abstractions;

namespace UnitTest.KazApi.Domain._Monster
{
    public class MonsterTest
    {
        private readonly ITestOutputHelper _output;
        private readonly ILog<BattleMetaData> _logger;
        private readonly IMonster _absHitMonster;
        private readonly IMonster _noDodgeMonster;
        private readonly IMonster _healMonster;

        public MonsterTest(ITestOutputHelper output)
        {
            _output = output;

            _logger = new BattleLogger();

            _absHitMonster = new Monster(
                MockMonsterParams.NoDodge,
                MockSkillSets.AbsHitOnly,
                []);
            _noDodgeMonster = new Monster(
                MockMonsterParams.NoDodge,
                MockSkillSets.NoMoveOnly,
                []);
            _healMonster = new Monster(
                MockMonsterParams.NoDodge,
                MockSkillSets.HealOnly,
                []
                );
        }

        [Fact(DisplayName = "スキルを選択")]
        public void UT001()
        {
            for (int i = 0; i < 1000; i++)
            {
                var skill = _absHitMonster.SelectSkill();
                
                Assert.True(skill is not null);
                Assert.True(skill is ISkill);
            }
        }

        [Fact(DisplayName = "攻撃")]
        public void UT002()
        {
            var monsters = new List<IMonster>()
            {
                _noDodgeMonster
            };

            int defaultHp = monsters[0].Hp;
            _absHitMonster.Move(monsters, _logger);

            Assert.True(monsters[0].Hp < defaultHp);
        }

        [Fact(DisplayName = "無害な攻撃")]
        public void UT003()
        {
            var monsters = new List<IMonster>()
            {
                _absHitMonster, _noDodgeMonster
            };

            _noDodgeMonster.Move(monsters, _logger);

            Assert.True(_absHitMonster.Hp == 100);
        }

        [Fact(DisplayName = "プラス効果")]
        public void UT004()
        {
            _healMonster.AcceptDamage(50);
            Assert.True(_healMonster.Hp == 50);
            var monsters = new List<IMonster>()
            {
                _absHitMonster, _healMonster
            };

            _healMonster.Move(monsters, _logger);

            Assert.True(_healMonster.Hp > 50);
        }
    }
}
