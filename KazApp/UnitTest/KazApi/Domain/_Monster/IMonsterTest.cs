using KazApi.Domain._Monster;
using KazApi.Domain._Monster._Skill;
using Microsoft.CodeAnalysis.Host.Mef;
using UnitTest.Mock;
using Xunit.Abstractions;

namespace UnitTest.KazApi.Domain._Monster
{
    public class IMonsterTest
    {
        private readonly ITestOutputHelper _output;
        private IList<IMonster> _monsters;
        private IMonster _monster;

        public IMonsterTest(ITestOutputHelper output)
        {
            _output = output;

            _monster = new Monster(
                    MockMonsterParams.NoDodge,
                    MockSkillSets.AbsHitOnly,
                    []);
        }

        [Fact(DisplayName = "")]
        public void UT001()
        {
            Assert.True(false);
        }

        [Fact(DisplayName = "")]
        public void UT002()
        {
            Assert.True(false);
        }

        [Fact(DisplayName = "")]
        public void UT003()
        {
            Assert.True(false);
        }
    }
}
