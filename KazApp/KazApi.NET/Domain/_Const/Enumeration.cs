using System.Reflection;

namespace KazApi.Domain._Const
{
    /// <summary>
    /// 定数値既定クラス
    /// </summary>
    public abstract class Enumeration<T>
    {
        public readonly T VALUE;
        public readonly string NAME;
        public readonly string SHORT_NAME;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        protected Enumeration(T value, string name, string shortName = "")
        {
            VALUE = value;
            NAME = name;
            SHORT_NAME = shortName;
        }

        public override string ToString() 
            => $"NAME: {NAME}, VALUE: {VALUE}, SHORT_NAME: {SHORT_NAME}" ?? "";

        /// <summary>
        /// フィールド名称の列挙を取得
        /// </summary>
        public static IEnumerable<string> FieldNames()
        {
            IList<string> result = [];
            Type fields = typeof(T);

            foreach (FieldInfo field in fields.GetFields())
            {
                result.Add(field.Name);
            }
            return result;
        }

        /// <summary>
        /// フィールド値の列挙を取得
        /// </summary>
        public static IEnumerable<object> FieldValues()
        {
            IList<object> result = [];
            Type fields = typeof(T);
            Type disabled = typeof(Enumeration<T>);

            foreach (FieldInfo field in fields.GetFields())
            {
                try
                {
                    result.Add(field.GetValue(fields) ?? "");
                }
                catch (ArgumentException)
                { }
            }
            return result;
        }
    }
}
