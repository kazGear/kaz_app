using KazApi.Domain._Monster._Skill;
using KazApi.Domain._Monster._State;
using KazApi.Domain._Monster;
using KazApi.Domain.DTO;

namespace UnitTest.Mock
{
    public static class MockSkillSets
    {
        public static readonly IEnumerable<ISkill> AbsHitOnly = new List<ISkill>()
        {
            MockSkills.AbsHit,
            MockSkills.AbsHit,
            MockSkills.AbsHit,
            MockSkills.AbsHit,
            MockSkills.AbsHit,
            MockSkills.AbsHit,
        };

        public static readonly IEnumerable<ISkill> AbsHitAllAttackOnly = new List<ISkill>()
        {
            MockSkills.AbsHitAllTarget,
            MockSkills.AbsHitAllTarget,
            MockSkills.AbsHitAllTarget,
            MockSkills.AbsHitAllTarget,
            MockSkills.AbsHitAllTarget,
            MockSkills.AbsHitAllTarget,
        };

        public static readonly IEnumerable<ISkill> AbsHitAllOrSingleTargetOnly = new List<ISkill>()
        {
            MockSkills.AbsHitAllOrSingleTargetFire,
            MockSkills.AbsHitAllOrSingleTargetFire,
            MockSkills.AbsHitAllOrSingleTargetFire,
            MockSkills.AbsHitAllOrSingleTargetFire,
            MockSkills.AbsHitAllOrSingleTargetFire,
            MockSkills.AbsHitAllOrSingleTargetFire,
        };

        public static readonly IEnumerable<ISkill> HealOnly = new List<ISkill>()
        {
            MockSkills.HealMagic,
            MockSkills.HealMagic,
            MockSkills.HealMagic,
            MockSkills.HealMagic,
            MockSkills.HealMagic,
            MockSkills.HealMagic,
        };

        public static readonly IEnumerable<ISkill> InvalidTargetOnly = new List<ISkill>()
        {
            MockSkills.InvalidTarget,
            MockSkills.InvalidTarget,
            MockSkills.InvalidTarget,
            MockSkills.InvalidTarget,
            MockSkills.InvalidTarget,
            MockSkills.InvalidTarget,
        };
    }
}
