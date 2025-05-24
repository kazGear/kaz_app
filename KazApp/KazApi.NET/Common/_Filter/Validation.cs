using KazApi.Domain._Const;
using KazApi.Domain._Monster;
using KazApi.Domain._Monster._State;
using System.Text.RegularExpressions;

namespace KazApi.Common._Filter
{
    public static class Validation
    {
        private static readonly string _messageUndefinedElement = "定義されていない属性です。";
        private static readonly string _messageUndefinedSkill = "定義されていないスキルです。";
        private static readonly string _messageUndefinedState = "定義されていない状態です。";

        public static int Attack(int attack)
        {
            int min = 0;
            int max = 255;
            string message = $"攻撃力は{min}-{max}の範囲で設定してください。";

            if (attack < min) throw new Exception(message);
            if (max < attack) throw new Exception(message);

            return attack;
        }

        public static string CodeId(string codeId)
        {
            string pattern = @"^code\d{3}$";

            if (!Regex.IsMatch(codeId, pattern))
                throw new Exception("コードIDのパターンが異なります。");

            return codeId;
        }

        public static int CodeValue(int codeValue)
        {
            int min = 0;
            int max = 99;
            string message = $"コード値は{min}-{max}の範囲で設定してください。";

            if (codeValue < min) throw new Exception(message);
            if (max < codeValue) throw new Exception(message);

            return codeValue;
        }

        public static double Critical(double critical)
        {
            double min = 0.0;
            double max = 1.0;
            string message = $"クリティカル率は{min}-{max}の範囲で設定してください。";

            if (critical < min) throw new Exception(message);
            if (max < critical) throw new Exception(message);

            return critical;
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

        public static double HitRate(double hitRate)
        {
            double min = 0.0;
            double max = 1.0;
            string message = $"ヒット率は{min}-{max}の範囲で設定してください。";

            if (hitRate < min) throw new Exception(message);
            if (max < hitRate) throw new Exception(message);

            return hitRate;
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

        public static string ItemId(string itemId)
        {
            string pattern = @"^[a-zA-Z]+\d{3}$";

            if (!Regex.IsMatch(itemId, pattern))
                throw new Exception("アイテムIDのパターンが異なります。");

            return itemId;
        }

        public static string MonsterId(string monsterId)
        {
            string pattern = @"^monster\d{3}$";

            if (!Regex.IsMatch(monsterId, pattern))
                throw new Exception("モンスターIDのパターンが異なります。");

            return monsterId;
        }

        public static string Name(string name)
        {
            int maxLength = 15;

            if (maxLength < name.Length)
                throw new Exception($"名称は{maxLength}文字以内にしてください。");

            return name;
        }

        public static int Price(int price)
        {
            if (price < 0)
                throw new Exception("価格は０円以上で設定してください。");

            return price;
        }

        public static string ShopId(string shopId)
        {
            string pattern = @"^shop\d{3}$";

            if (!Regex.IsMatch(shopId, pattern))
                throw new Exception("ショップIDのパターンが異なります。");

            return shopId;
        }

        public static string ShortName(string shortName)
        {
            int maxLength = 5;

            if (maxLength < shortName.Length)
                throw new Exception($"省略名は{maxLength}文字以内にしてください。");

            return shortName;
        }

        public static string MonsterType(string monsterType)
        {
            IReadOnlyCollection<string> values = CMonsterType.GetValues();

            if (!values.Contains(monsterType))
                throw new Exception("未定義のモンスタータイプです。");

            return monsterType;
        }

        public static string SkillId(string skillId)
        {
            string pattern = @"^skill\d{3}$";

            if (!Regex.IsMatch(skillId, pattern))
                throw new Exception("スキルIDのパターンが異なります。");

            return skillId;
        }

        public static int SkillType(int skillType)
        {
            IReadOnlyCollection<int> values = CSkillType.GetValues();

            if (!values.Contains(skillType))
                throw new Exception(_messageUndefinedSkill);

            return skillType;
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

        public static int StateType(int stateType)
        {
            IReadOnlyCollection<int> values = CStateType.GetValues();

            if (!values.Contains(stateType))
                throw new Exception(_messageUndefinedState);

            return stateType;
        }

        public static int TargetType(int stateType)
        {
            IReadOnlyCollection<int> values = CStateType.GetValues();

            if (!values.Contains(stateType))
                throw new Exception(_messageUndefinedState);

            return stateType;
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
