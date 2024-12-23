﻿using CSLib.Lib;
using KazApi.Common._Log;
using KazApi.Domain._Const;
using KazApi.Domain.DTO;

namespace KazApi.Domain._Monster._Skill
{
    /// <summary>
    /// スキルインターフェイス
    /// </summary>
    public abstract class ISkill
    {

        protected readonly ILog<BattleMetaData> _Log = new BattleLogger();
        protected int _initialAttack;

        public string SkillId { get; protected set; }
        public string SkillName { get; protected set; }
        public int SkillType { get; protected set; }
        public int Attack { get; protected set; }
        public int ElementType { get; protected set; }
        public int StateType { get; protected set; }
        public int TargetType { get; protected set; }
        //public string EffectFilePath { get; protected set; }
        public int Weight { get; protected set; }
        public double Critical { get; protected set; }
        public int EffectTime { get; protected set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ISkill(SkillDTO dto, string effectFilePath)
        {
            SkillId = dto.SkillId;
            SkillName = dto.SkillName;
            SkillType = dto.SkillType;
            Attack = dto.Attack;
            _initialAttack = dto.Attack;
            ElementType = dto.ElementType;
            StateType = dto.StateType;
            TargetType = dto.TargetType;
            Weight = dto.Weight;
            Critical = dto.Critical;
            EffectTime = dto.EffectTime;
        }

        /// <summary>
        /// スキルを使用
        /// </summary>
        public abstract void Use(IEnumerable<IMonster> monsters, IMonster me);

        /// <summary>
        /// 全体攻撃の際は威力減少
        /// </summary>
        public void PowerDown()
        {
            double allAttackDamage = Attack * URandom.RandomDouble(
                CSysRate.ALL_ATTACK_ADJUST_MIN.VALUE,
                CSysRate.ALL_ATTACK_ADJUST_MAX.VALUE
                );
            Attack = (int)allAttackDamage;
        }

        /// <summary>
        /// 攻撃力を初期値に戻す
        /// </summary>
        protected void InitPower()
            => Attack = _initialAttack;
    }
}
