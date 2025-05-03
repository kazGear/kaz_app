using KazApi.Domain._Monster._Skill;
using KazApi.Domain._Monster._State;
using KazApi.Domain._Monster;
using KazApi.Domain.DTO;

namespace UnitTest.Mock
{
    public static class MockSkills
    {
        public static readonly ISkill Damage001 = new DamageSkill(new SkillDTO()
        {
            SkillId = "skill001",
            SkillName = "打撃",
            SkillType = 1,
            ElementType = 0,
            StateType = 0,
            TargetType = 1,
            Attack = 10,
            Weight = 10,
            DefaultCritical = 0.1,
            Critical = 0.1,
            HitRate = 0.9,
        });

        public static readonly ISkill Damage002 = new DamageSkill(new SkillDTO()
        {
            SkillId = "skill002",
            SkillName = "正拳突き",
            SkillType = 1,
            ElementType = 0,
            StateType = 0,
            TargetType = 1,
            Attack = 20,
            Weight = 20,
            DefaultCritical = 0.1,
            Critical = 0.1,
            HitRate = 0.85,
        });

        public static readonly ISkill Damage004 = new DamageSkill(new SkillDTO()
        {
            SkillId = "skill004",
            SkillName = "リアルインパクト",
            SkillType = 1,
            ElementType = 0,
            StateType = 0,
            TargetType = 1,
            Attack = 50,
            Weight = 50,
            DefaultCritical = 0.1,
            Critical = 0.1,
            HitRate = 0.7,
        });

        public static readonly ISkill Damage017 = new DamageSkill(new SkillDTO()
        {
            SkillId = "skill017",
            SkillName = "ファイアボール",
            SkillType = 3,
            ElementType = 1,
            StateType = 0,
            TargetType = 3,
            Attack = 10,
            Weight = 10,
            DefaultCritical = 0.0,
            Critical = 0.0,
            HitRate = 1.0,
        });

        public static readonly ISkill Heal039 = new HealSkill(new SkillDTO()
        {
            SkillId = "skill039",
            SkillName = "ケアル",
            SkillType = 6,
            ElementType = 0,
            StateType = 0,
            TargetType = 6,
            Attack = 20,
            Weight = 20,
            DefaultCritical = 0.0,
            Critical = 0.0,
            HitRate = 1,
        });

        public static readonly ISkill Heal042 = new HealSkill(new SkillDTO()
        {
            SkillId = "skill042",
            SkillName = "ケアルジャ",
            SkillType = 6,
            ElementType = 0,
            StateType = 0,
            TargetType = 6,
            Attack = 60,
            Weight = 50,
            DefaultCritical = 0.0,
            Critical = 0.0,
            HitRate = 1,
        });

        public static readonly ISkill Heal043 = new HealSkill(new SkillDTO()
        {
            SkillId = "skill043",
            SkillName = "リジェネ",
            SkillType = 7,
            ElementType = 0,
            StateType = 8,
            TargetType = 6,
            Attack = 0,
            Weight = 20,
            DefaultCritical = 0.0,
            Critical = 0.0,
            HitRate = 1,
        });

        public static readonly ISkill NoMove055 = new NoMoveSkill(new SkillDTO()
        {
            SkillId = "skill055",
            SkillName = "ミスをした",
            SkillType = 8,
            ElementType = 0,
            StateType = 0,
            TargetType = 0,
            Attack = 0,
            Weight = 0,
            DefaultCritical = 0.0,
            Critical = 0.0,
            HitRate = 1,
        });

    }
}
