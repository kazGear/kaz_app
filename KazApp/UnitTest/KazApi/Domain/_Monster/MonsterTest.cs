using KazApi.Domain._Monster;
using KazApi.Domain._Monster._Skill;
using KazApi.Domain._Monster._State;
using Microsoft.CodeAnalysis.Host.Mef;
using UnitTest.Mock;
using Xunit.Abstractions;

namespace UnitTest.KazApi.Domain._Monster
{
    public class MonsterTest
    {
        private readonly ITestOutputHelper _output;
        private readonly IMonster _absHitMonster;
        private readonly IMonster _noMoveMonster;
        private readonly IMonster _healMonster;

        public MonsterTest(ITestOutputHelper output)
        {
            _output = output;

            _absHitMonster = new Monster(
                MockMonsterParams.NoDodge,
                MockSkillSets.AbsHitOnly,
                []);
            _noMoveMonster = new Monster(
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
                _absHitMonster, _noMoveMonster
            };

            _absHitMonster.Move(monsters);

            Assert.True(_noMoveMonster.Hp < 100);
        }

        [Fact(DisplayName = "無害な攻撃")]
        public void UT003()
        {
            var monsters = new List<IMonster>()
            {
                _absHitMonster, _noMoveMonster
            };

            _noMoveMonster.Move(monsters);

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

            _healMonster.Move(monsters);

            Assert.True(_healMonster.Hp > 50);
        }
    }
}
