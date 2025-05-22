using KazApi.Domain._Const;

namespace KazApi.Common._Filter
{
    public static class Validation
    {
        private static readonly string _messageUndefinedElement = "定義されていない属性です。";

        public static int Attack(int attack)
        {
            int min = 0;
            int max = 255;
            string message = $"攻撃力は{min}-{max}の範囲で設定してください。";

            if (attack < min) throw new Exception(message);
            if (max < attack) throw new Exception(message);

            return attack;
        }

        public static double Dodge(double dodge)
        {
            double min = 0.0;
            double max = 1.0;
            string message = $"素早さは{min}-{max}の範囲で設定してください。";

            if (dodge < min) throw new Exception(message);
            if (max < dodge) throw new Exception(message);

            return dodge;
        }        

        public static int Hp(int hp)
        {
            int min = 0;
            int max = 999;
            string message = $"HPは{min}-{max}の範囲で設定してください。";

            if (hp < min) throw new Exception(message);
            if (max < hp) throw new Exception(message);

            return hp;
        }

        public static string MonsterName(string monsterName)
        {
            int maxLength = 10;

            if (maxLength < monsterName.Length)
                throw new Exception($"モンスター名は{maxLength}文字以内にしてください。");

            return monsterName;
        }

        public static string MonsterType(string monsterType)
        {
            IReadOnlyCollection<string> values = CMonsterType.GetValues();

            if (!values.Contains(monsterType))
                throw new Exception("未定義のモンスタータイプです。");

            return monsterType;
        }

        public static int Speed(int speed)
        {
            int min = 0;
            int max = 255;
            string message = $"素早さは{min}-{max}の範囲で設定してください。";

            if (speed < min) throw new Exception(message);
            if (max < speed) throw new Exception(message);

            return speed;
        }

        public static int Week(int week)
        {
            IReadOnlyCollection<int> values = CElement.GetValues();

            if (!values.Contains(week))
                throw new Exception(_messageUndefinedElement);

            return week;
        }
    }
}
