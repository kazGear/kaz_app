﻿using CSLib.Lib;
using KazApi.Common._Log;
using KazApi.Domain._Const;
using KazApi.Domain._GameSystem;
using KazApi.Domain.DTO;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace KazApi.Domain._Monster._Skill
{
    /// <summary>
    /// ダメージ付与クラス
    /// </summary>
    public class DamageSkill : ISkill
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public DamageSkill(SkillDTO dto, string effectFilePath)
                    : base(dto, effectFilePath) { }

        public override void Use(IEnumerable<IMonster> monsters, IMonster me)
        {
            int target = OneOrAll();

            if (target == CTarget.ENEMY_RANDOM.VALUE) // 単体攻撃
            {
                IMonster enemy = BattleSystem.SelectOneEnemy(monsters);
                AttackEnemy(enemy, me);
            }
            else if (target == CTarget.ENEMY_ALL.VALUE) // 全体攻撃
            {
                // 全体攻撃は威力弱め
                PowerDown();
                monsters = monsters.Where(e => e.Hp > 0);
                foreach (IMonster enemy in monsters) AttackEnemy(enemy, me);
                InitPower();
            }
            else
            {
                throw new Exception("不適切なターゲットタイプです。");
            }
        }
        /// <summary>
        /// 敵を攻撃
        /// </summary>
        private void AttackEnemy(IMonster enemy, IMonster me)
        {
            // 攻撃回避
            if (!IsHitSkill(this))
            {
                MissLogging(enemy);
                return;
            }

            // ダメージ量が多少揺れる
            int damage = URandom.RandomChangeInt(Attack + me.Attack, CSysRate.PHYSICAL_SKILL_DAMAGE.VALUE);

            // 弱点等のダメージ欲正
            damage = WeeknessDamage(this, enemy, damage);
            damage = CriticalDamage(this, damage);

            HitLogging(enemy, damage);
            enemy.AcceptDamage(damage);
        }
        /// <summary>
        /// 攻撃がヒットした際のログ
        /// </summary>
        /// <param name="enemy"></param>
        /// <param name="damage"></param>
        private void HitLogging(IMonster enemy, int damage)
        {
            _log.Logging(new BattleMetaData(
                enemy.MonsterId,
                enemy.Hp,
                damage,
                SkillId,
                EffectTime,
                $"{enemy.MonsterName}は{damage}のダメージを受けた。")
                );
        }
        /// <summary>
        /// 攻撃を外した際際のログ
        /// </summary>
        private void MissLogging(IMonster enemy)
        {
            int noDamage = 0;
            string missSkill = "";
            int noEffectTime = 0;

            _log.Logging(new BattleMetaData(
                enemy.MonsterId,
                enemy.Hp,
                noDamage,
                missSkill,
                noEffectTime,
                $"{enemy.MonsterName}は攻撃を回避した！")
                );
        }
        /// <summary>
        /// 単体攻撃か全体攻撃かを選択する
        /// </summary>
        private int OneOrAll()
        {
            if (base.TargetType == CTarget.ENEMY_RANDOM_OR_ALL.VALUE)
            {
                return URandom.RandomBool() ? CTarget.ENEMY_RANDOM.VALUE
                                            : CTarget.ENEMY_ALL.VALUE;
            }
            return base.TargetType;
        }
    }
}
