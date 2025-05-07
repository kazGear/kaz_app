using KazApi.Domain._Monster._Skill;
using KazApi.Domain.DTO;

namespace UnitTest.Mock
{
    public static class MockSkills
    {
        public static readonly ISkill AbsHit = new DamageSkill(new SkillDTO()
        {
            SkillId = "skill001",
            SkillName = "打撃（必中）",
            SkillType = 1,
            ElementType = 0,
            StateType = 0,
            TargetType = 1,
            Attack = 10,
            Weight = 10,
            DefaultCritical = 0.1,
            Critical = 0.1,
            HitRate = 1.0,
        });

        public static readonly ISkill HalfHit = new DamageSkill(new SkillDTO()
        {
            SkillId = "skill001",
            SkillName = "打撃（5割当たる）",
            SkillType = 1,
            ElementType = 0,
            StateType = 0,
            TargetType = 1,
            Attack = 10,
            Weight = 10,
            DefaultCritical = 0.1,
            Critical = 0.1,
            HitRate = 0.5,
        });

        public static readonly ISkill AbsHitCritical = new DamageSkill(new SkillDTO()
        {
            SkillId = "skill001_1",
            SkillName = "打撃(Critical)",
            SkillType = 1,
            ElementType = 0,
            StateType = 0,
            TargetType = 1,
            Attack = 10,
            Weight = 10,
            DefaultCritical = 1.0,
            Critical = 1, // 必ずクリティカル
            HitRate = 1.0, // 必ず当たる
        });

        public static readonly ISkill InvalidTarget = new DamageSkill(new SkillDTO()
        {
            SkillId = "skill001",
            SkillName = "打撃（無効なターゲット）",
            SkillType = 1,
            ElementType = 0,
            StateType = 0,
            TargetType = -1,
            Attack = 10,
            Weight = 10,
            DefaultCritical = 0.1,
            Critical = 0.1,
            HitRate = 0.9,
        });

        public static readonly ISkill AbsHitAllTarget = new DamageSkill(new SkillDTO()
        {
            SkillId = "skill005",
            SkillName = "回し蹴り（必中全体）",
            SkillType = 1,
            ElementType = 0,
            StateType = 0,
            TargetType = 2,
            Attack = 10,
            Weight = 10,
            DefaultCritical = 0.1,
            Critical = 0.1,
            HitRate = 1.0,
        });

        public static readonly ISkill AbsHitAllOrSingleTargetFire = new DamageSkill(new SkillDTO()
        {
            SkillId = "skill017",
            SkillName = "ファイアボール（必中）",
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

        public static readonly ISkill FireSingleTargetMagic = new DamageSkill(new SkillDTO()
        {
            SkillId = "skill017",
            SkillName = "ファイアボール（必中単体）",
            SkillType = 3,
            ElementType = 1,
            StateType = 0,
            TargetType = 1,
            Attack = 10,
            Weight = 10,
            DefaultCritical = 0.0,
            Critical = 0.0,
            HitRate = 1.0,
        });

        public static readonly ISkill IceSingleTarget = new DamageSkill(new SkillDTO()
        {
            SkillId = "skill020",
            SkillName = "アイススマッシュ（必中単体）",
            SkillType = 3,
            ElementType = 3,
            StateType = 0,
            TargetType = 1,
            Attack = 10,
            Weight = 10,
            DefaultCritical = 0.0,
            Critical = 0.0,
            HitRate = 1.0,
        });

        public static readonly ISkill RateDamage = new RateDamageSkill(new SkillDTO()
        {
            SkillId = "skill036",
            SkillName = "グラビガ（必中）",
            SkillType = 4,
            ElementType = 0,
            StateType = 0,
            TargetType = 1,
            Attack = 50, // ５０％ダメージ
            Weight = 30,
            DefaultCritical = 0.0,
            Critical = 0.0,
            HitRate = 1,
        });

        public static readonly ISkill DeadMagic = new DeadSkill(new SkillDTO()
        {
            SkillId = "skill038",
            SkillName = "デススペル（必中）",
            SkillType = 5,
            ElementType = 0,
            StateType = 0,
            TargetType = 1,
            Attack = 0,
            Weight = 40,
            DefaultCritical = 0.0,
            Critical = 0.0,
            HitRate = 1,
        });

        public static readonly ISkill HealMagic = new HealSkill(new SkillDTO()
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

        public static readonly ISkill AutoHeal = new StateSkill(new SkillDTO()
        {
            SkillId = "skill043",
            SkillName = "リジェネ", // 良い状態
            SkillType = 7,
            ElementType = 0,
            StateType = 8,
            TargetType = 6,
            Attack = 0,
            Weight = 20,
            DefaultCritical = 0.0,
            Critical = 0.0,
            HitRate = 1,
        }, MockStatus.AUTOHEAL);

        public static readonly ISkill Poison = new StateSkill(new SkillDTO()
        {
            SkillId = "skill044",
            SkillName = "ポイズン", // 悪い状態
            SkillType = 7,
            ElementType = 0,
            StateType = 1,
            TargetType = 1,
            Attack = 0,
            Weight = 20,
            DefaultCritical = 0.0,
            Critical = 0.0,
            HitRate = 1.0, // 必中
        }, MockStatus.POISON);

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
