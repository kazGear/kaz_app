using KazApi.Common._Log;
using KazApi.Domain._Const;
using KazApi.Domain.DTO;

namespace KazApi.Domain._Monster._State
{
    /// <summary>
    /// スロー状態クラス
    /// </summary>
    public class Slow : IState
    {
        private static readonly double DOWN_RATE = 0.25;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Slow(StateDTO dto) : base(dto)
        {
            base.Activate = true;
        }
        
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Slow(string name, string shortName, int stateType, double cancelRate) 
             : base(name, shortName, stateType, cancelRate)
        {
            base.StateType = CStateType.SLOW.VALUE;
            base.Activate = true;
        }

        public override IState DeepCopy()
            => new Slow(base.Name, base.ShortName, base.StateType, base.CancelRate);

        public override void DisabledLogging(IMonster me)
        {
            me.InitSpeed();

            base._log.Logging(new BattleMetaData(
                me.MonsterId,
                base._disabledState,
                base.ShortName,
                $"{me.MonsterName}のスロー状態が解除された。")
                );
        }

        /// <summary>
        /// モンスターの行動速度を遅くする
        /// </summary>
        public override void Impact(IMonster me)
        {
            if (me.Speed == me.DefaultSpeed)
            {
                double downedSpeed = me.Speed * DOWN_RATE;
                me.SetSpeed((int)downedSpeed);

                base._log.Logging(new BattleMetaData(
                    me.MonsterId,
                    $"{me.MonsterName}はスロー状態になった。")
                    );
            }



        }
    }
}
