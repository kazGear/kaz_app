using KazApi.Domain._Const;
using KazApi.Domain._Monster;
using KazApi.Domain._Monster._Skill;
using KazApi.Domain._Monster._State;
using Microsoft.CodeAnalysis.Host.Mef;
using UnitTest.Mock;
using Xunit.Abstractions;

namespace UnitTest.KazApi.Domain._Skill
{
    public class StateSkillTest
    {
        private readonly ITestOutputHelper _output;
        private readonly IMonster _monster;
        private readonly ISkill _positiveStateSkill;
        private readonly ISkill _nagativeStateSkill;

        public StateSkillTest(ITestOutputHelper output)
        {
            _output = output;
            _monster = new Monster(
                MockMonsterParams.NoDodge,
                MockSkillSets.HealOnly,
                []
                );
            _positiveStateSkill = MockSkills.AutoHeal;
            _nagativeStateSkill = MockSkills.Poison;
        }

        [Fact(DisplayName = "良い状態")]
        public void UT001()
        {
            var beforeStatus = _monster.CurrentStatus();
            Assert.True(beforeStatus.Count() == 0);

            _positiveStateSkill.Use([_monster], _monster);

            IList<IState> afterStatus = (IList<IState>)_monster.CurrentStatus();
            Assert.True(afterStatus.Count() == 1);
            Assert.True(afterStatus[0] is AutoHeal);
        }

        [Fact(DisplayName = "悪い状態")]
        public void UT002()
        {
            var beforeStatus = _monster.CurrentStatus();
            Assert.True(beforeStatus.Count() == 0);

            _nagativeStateSkill.Use([_monster], _monster);

            IList<IState> afterStatus = (IList<IState>)_monster.CurrentStatus();
            Assert.True(afterStatus.Count() == 1);
            Assert.True(afterStatus[0] is Poison);
        }

        [Fact(DisplayName = "複数の状態保持")]
        public void UT003()
        {
            var beforeStatus = _monster.CurrentStatus();
            Assert.True(beforeStatus.Count() == 0);

            _positiveStateSkill.Use([_monster], _monster);
            _nagativeStateSkill.Use([_monster], _monster);

            IList<IState> afterStatus = (IList<IState>)_monster.CurrentStatus();
            Assert.True(afterStatus.Count() == 2);
            foreach (var state in afterStatus)
                Assert.True(state is Poison || state is AutoHeal);
        }

        [Fact(DisplayName = "状態は重複しない(nagative)")]
        public void UT004()
        {
            var beforeStatus = _monster.CurrentStatus();
            Assert.True(beforeStatus.Count() == 0);

            _nagativeStateSkill.Use([_monster], _monster);
            _nagativeStateSkill.Use([_monster], _monster);

            var afterStatus = _monster.CurrentStatus();
            Assert.True(afterStatus.Count() == 1);
        }

        [Fact(DisplayName = "状態は重複しない(positive)")]
        public void UT005()
        {
            var beforeStatus = _monster.CurrentStatus();
            Assert.True(beforeStatus.Count() == 0);

            _positiveStateSkill.Use([_monster], _monster);
            _positiveStateSkill.Use([_monster], _monster);

            var afterStatus = _monster.CurrentStatus();
            Assert.True(afterStatus.Count() == 1);
        }
    }
}
