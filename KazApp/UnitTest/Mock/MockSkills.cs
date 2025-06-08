using KazApi.Domain._Const;
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
            SkillType = CSkillType.BLOW.VALUE,
            ElementType = CElement.NONE.VALUE,
            StateType = CStateType.NONE.VALUE,
            TargetType = CTarget.ENEMY_RANDOM.VALUE,
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
            SkillType = CSkillType.BLOW.VALUE,
            ElementType = CElement.NONE.VALUE,
            StateType = CStateType.NONE.VALUE,
            TargetType = CTarget.ENEMY_RANDOM.VALUE,
            Attack = 10,
            Weight = 10,
            DefaultCritical = 0.1,
            Critical = 0.1,
            HitRate = 0.5,
        });

        public static readonly ISkill AbsHitCritical = new DamageSkill(new SkillDTO()
        {
            SkillId = "skill001",
            SkillName = "打撃(Critical)",
            SkillType = CSkillType.BLOW.VALUE,
            ElementType = CElement.NONE.VALUE,
            StateType = CStateType.NONE.VALUE,
            TargetType = CTarget.ENEMY_RANDOM.VALUE,
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
            SkillType = CSkillType.BLOW.VALUE,
            ElementType = CElement.NONE.VALUE,
            StateType = CStateType.NONE.VALUE,
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
            SkillType = CSkillType.BLOW.VALUE,
            ElementType = CElement.NONE.VALUE,
            StateType = CStateType.NONE.VALUE,
            TargetType = CTarget.ENEMY_ALL.VALUE,
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
            SkillType = CSkillType.ATTACK_MAGIC.VALUE,
            ElementType = CElement.FIRE.VALUE,
            StateType = CStateType.NONE.VALUE,
            TargetType = CTarget.ENEMY_RANDOM_OR_ALL.VALUE,
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
            SkillType = CSkillType.ATTACK_MAGIC.VALUE,
            ElementType = CElement.FIRE.VALUE,
            StateType = CStateType.NONE.VALUE,
            TargetType = CTarget.ENEMY_RANDOM.VALUE,
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
            SkillType = CSkillType.ATTACK_MAGIC.VALUE,
            ElementType = CElement.ICE.VALUE,
            StateType = CStateType.NONE.VALUE,
            TargetType = CTarget.ENEMY_RANDOM.VALUE,
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
            SkillType = CSkillType.ATTACK_RATE.VALUE,
            ElementType = CElement.NONE.VALUE,
            StateType = CStateType.NONE.VALUE,
            TargetType = CTarget.ENEMY_RANDOM.VALUE,
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
            SkillType = CSkillType.DEAD.VALUE,
            ElementType = CElement.NONE.VALUE,
            StateType = CStateType.NONE.VALUE,
            TargetType = CTarget.ENEMY_RANDOM.VALUE,
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
            SkillType = CSkillType.HEAL.VALUE,
            ElementType = CElement.NONE.VALUE,
            StateType = CStateType.NONE.VALUE,
            TargetType = CTarget.FRIEND_RANDOM.VALUE,
            Attack = 20,
            Weight = 20,
            DefaultCritical = 0.0,
            Critical = 0.0,
            HitRate = 1,
        });

        public static readonly ISkill AutoHeal = new StateSkill(new SkillDTO()
        {
            SkillId = "skill043",
            SkillName = "リジェネ", // 良い状態
            SkillType = CSkillType.STATE.VALUE,
            ElementType = CElement.NONE.VALUE,
            StateType = CStateType.AUTOHEAL.VALUE,
            TargetType = CTarget.FRIEND_RANDOM.VALUE,
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
            SkillType = CSkillType.STATE.VALUE,
            ElementType = CElement.NONE.VALUE,
            StateType = CStateType.POISON.VALUE,
            TargetType = CTarget.ENEMY_RANDOM.VALUE,
            Attack = 0,
            Weight = 20,
            DefaultCritical = 0.0,
            Critical = 0.0,
            HitRate = 1.0, // 必中
        }, MockStatus.POISON);

        public static readonly ISkill Sleep = new StateSkill(new SkillDTO()
        {
            SkillId = "skill047",
            SkillName = "スリプル", // 悪い状態
            SkillType = CSkillType.STATE.VALUE,
            ElementType = CElement.NONE.VALUE,
            StateType = CStateType.SLEEP.VALUE,
            TargetType = CTarget.ENEMY_RANDOM.VALUE,
            Attack = 0,
            Weight = 20,
            DefaultCritical = 0.0,
            Critical = 0.0,
            HitRate = 1.0, // 必中
        }, MockStatus.SLEEP);

        public static readonly ISkill Charm = new StateSkill(new SkillDTO()
        {
            SkillId = "skill049",
            SkillName = "チャーム", // 悪い状態
            SkillType = CSkillType.STATE.VALUE,
            ElementType = CElement.NONE.VALUE,
            StateType = CStateType.CHARM.VALUE,
            TargetType = CTarget.ENEMY_RANDOM.VALUE,
            Attack = 0,
            Weight = 20,
            DefaultCritical = 0.0,
            Critical = 0.0,
            HitRate = 1.0, // 必中
        }, MockStatus.CHARM);

        public static readonly ISkill NoMove055 = new NoMoveSkill(new SkillDTO()
        {
            SkillId = "skill055",
            SkillName = "ミスをした",
            SkillType = CSkillType.NOT_MOVE.VALUE,
            ElementType = CElement.NONE.VALUE,
            StateType = CStateType.NONE.VALUE,
            TargetType = CStateType.NONE.VALUE,
            Attack = 0,
            Weight = 0,
            DefaultCritical = 0.0,
            Critical = 0.0,
            HitRate = 1,
        });
    }
}
