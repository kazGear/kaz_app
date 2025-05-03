using KazApi.Domain._Monster._Skill;
using KazApi.Domain._Monster._State;
using KazApi.Domain._Monster;
using KazApi.Domain.DTO;

namespace UnitTest.Mock
{
    public static class MockSkillSets
    {
        public static readonly IEnumerable<ISkill> AttackOnly = new List<ISkill>()
        {
            MockSkills.Damage001,
            MockSkills.Damage001,
            MockSkills.Damage001,
            MockSkills.Damage001,
            MockSkills.Damage001,
            MockSkills.Damage001,
        };

        public static readonly IEnumerable<ISkill> FireOnly = new List<ISkill>()
        {
            MockSkills.Damage017,
            MockSkills.Damage017,
            MockSkills.Damage017,
            MockSkills.Damage017,
            MockSkills.Damage017,
            MockSkills.Damage017,
        };

        public static readonly IEnumerable<ISkill> HealOnly = new List<ISkill>()
        {
            MockSkills.Heal039,
            MockSkills.Heal039,
            MockSkills.Heal039,
            MockSkills.Heal039,
            MockSkills.Heal039,
            MockSkills.Heal039,
        };
    }
}
