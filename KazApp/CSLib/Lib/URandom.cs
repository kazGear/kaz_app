namespace CSLib.Lib
{
    /// <summary>
    /// 乱数ユーティリティ
    /// </summary>
    public class URandom
    {
        private readonly int _seed;

        /// <summary>
        /// コンストラクタ
        /// 乱数シードが毎回変わる
        /// </summary>
        public URandom()
        {
            DateTime dt = DateTime.Now;
            _seed = dt.Second + dt.Millisecond + dt.Nanosecond;
        }

        /// <summary>
        /// int型の乱数を取得（範囲指定）
        /// minValue: 下限を含む
        /// maxValue: 排他的な上限（その数値は含まない）
        /// </summary>
        public int RandomInt(int minValue, int maxValue)
        {
            Random r = new Random(_seed);
            return r.Next(minValue, maxValue);
        }

        /// <summary>
        /// double型の乱数を取得（範囲指定） 
        /// minValue: 下限を含む
        /// maxValue: 排他的な上限（その数値は含まない）
        /// </summary>
        public double RandomDouble(double minValue, double maxValue)
        {
            Random r = new Random(_seed);
            return r.NextDouble() * (maxValue - minValue) + minValue;
        }

        /// <summary>
        /// 対象の数値を rate(%) に応じて増減させる 
        /// </summary>
        public int RandomChangeInt(int target, double rate)
        {
            double adjust = target * RandomDouble(0, rate);
            bool randBool = RandomBool();

            // 負数に変換
            if (!randBool) adjust *= -1;

            return target + (int)adjust;
        }

        /// <summary>
        /// true / false のいずれかを生成 
        /// </summary>
        public bool RandomBool()
        {
            Random r = new Random(_seed);
            int oneOrzero = r.Next(0, 2); // 0 or 1

            return 1 == oneOrzero ? true : false;
        }
    }
}
