using KazApi.Common._Log;
using KazApi.Domain.DTO;

namespace KazApi.Domain._Monster._State
{
    /// <summary>
    /// 状態異常インターフェイス
    /// </summary>
    public abstract class IState
    {
        protected readonly ILog<BattleMetaData> _Log = new BattleLogger();

        public string Name { get; protected set; }
        public string ShortName { get; protected set; }
        public int StateType { get; protected set; }
        public double CancelRate { get; protected set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public IState(string name, string shortName, int stateType, double cancelRate)
        {
            Name = name;
            ShortName = shortName;
            StateType = stateType;
            CancelRate = cancelRate;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public IState(StateDTO dto)
        {
            Name = dto.Name;
            ShortName = dto.ShortName;
            StateType = dto.StateType;
            CancelRate = dto.CancelRate;
        }

        /// <summary>
        /// 状態タイプを取得
        /// </summary>
        public int GetStateType() => StateType;

        /// <summary>
        /// 新しくオブジェクトを生成
        /// </summary>
        public abstract IState DeepCopy();

        /// <summary>
        /// 状態解除時のログ
        /// </summary>
        public abstract void DisabledLogging(IMonster monster);

        /// <summary>
        /// 状態の影響をモンスターに与える
        /// </summary>
        public abstract void Impact(IMonster monster);
    }
}
