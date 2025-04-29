using KazApi.Domain._Const;
using KazApi.Domain.DTO;

namespace KazApi.Domain._Monster._State
{
    /// <summary>
    /// 状態異常なしクラス
    /// </summary>
    public class None : IState
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public None(StateDTO dto) : base(dto) { }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public None(string name, string shortName, int stateType, double cancelRate)
             : base(name, shortName, stateType, cancelRate)
        {
            StateType = CStateType.NONE.VALUE;
        }


        public override IState DeepCopy()
            => new None(base.Name, base.ShortName, base.StateType, base.CancelRate);

        public override void DisabledLogging(IMonster monster)
            => throw new NotImplementedException();

        /// <summary>
        /// 
        /// </summary>
        public override void Impact(IMonster monster)
        {
            throw new NotImplementedException();
        }
    }
}
