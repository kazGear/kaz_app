using KazApi.Domain._Const;
using System.Text.RegularExpressions;

namespace KazApi.Common._Filter
{
    public static class Validation
    {
        private static readonly string _messageUndefinedElement = "定義されていない属性です。";
        private static readonly string _messageUndefinedSkill = "定義されていないスキルです。";
        private static readonly string _messageUndefinedState = "定義されていない状態です。";

        private static string GetMessageSetWithinRange(string target, int min, int max)
        {
            return $"{target}は{min}-{max}の範囲で設定してください。";
        }
        private static string GetMessageSetWithinRange(string target, double min, double max)
        {
            return $"{target}は{min}-{max}の範囲で設定してください。";
        }

        private static string GetMessageNotMatching(string target)
        {
            return $"{target}のパターンが異なっています。";
        }

        public static int Amount(int amount)
        {
            if (amount < 0)
                throw new Exception($"金額は{amount}円以上で設定してください。");

            return amount;
        }

        public static int Attack(int attack)
        {
            int min = 0;
            int max = 255;

            string message = GetMessageSetWithinRange("攻撃力", min, max);

            if (attack < min) throw new Exception(message);
            if (max < attack) throw new Exception(message);

            return attack;
        }

        public static string CodeId(string codeId)
        {
            string pattern = @"^code\d{3}$";

            if (!Regex.IsMatch(codeId, pattern))
                throw new Exception(GetMessageNotMatching("コードID"));

            return codeId;
        }

        public static int CodeValue(int codeValue)
        {
            int min = 0;
            int max = 99;

            string message = GetMessageSetWithinRange("コード値", min, max);

            if (codeValue < min) throw new Exception(message);
            if (max < codeValue) throw new Exception(message);

            return codeValue;
        }

        public static int Count(int count)
        {
            if (count < 0)
                throw new Exception($"カウントは{count}以上で設定してください。");

            return count;
        }

        public static double Critical(double critical)
        {
            double min = 0.0;
            double max = 1.0;

            string message = GetMessageSetWithinRange("クリティカル率", min, max);

            if (critical < min) throw new Exception(message);
            if (max < critical) throw new Exception(message);

            return critical;
        }

        public static double Dodge(double dodge)
        {
            double min = 0.0;
            double max = 1.0;
         
            string message = GetMessageSetWithinRange("回避率", min, max);

            if (dodge < min) throw new Exception(message);
            if (max < dodge) throw new Exception(message);

            return dodge;
        }

        public static double HitRate(double hitRate)
        {
            double min = 0.0;
            double max = 1.0;

            string message = GetMessageSetWithinRange("ヒット率", min, max);

            if (hitRate < min) throw new Exception(message);
            if (max < hitRate) throw new Exception(message);

            return hitRate;
        }

        public static int Hp(int hp)
        {
            int min = 0;
            int max = 999;

            string message = GetMessageSetWithinRange("HP", min, max);

            if (hp < min) throw new Exception(message);
            if (max < hp) throw new Exception(message);

            return hp;
        }

        public static string ItemId(string itemId)
        {
            string pattern = @"^[a-zA-Z]+\d{3}$";

            if (!Regex.IsMatch(itemId, pattern))
                throw new Exception(GetMessageNotMatching("アイテムID"));

            return itemId;
        }

        public static string LoginId(string loginId)
        {
            string pattern = @"^[a-zA-Z0-9-_]{4,15}$";

            if (!Regex.IsMatch(loginId, pattern))
                throw new Exception(GetMessageNotMatching("ログインID"));

            return loginId;
        }

        public static string MonsterId(string monsterId)
        {
            string pattern = @"^monster\d{3}$";

            if (!Regex.IsMatch(monsterId, pattern))
                throw new Exception(GetMessageNotMatching("モンスターID"));

            return monsterId;
        }

        public static string MonsterType(string monsterType)
        {
            IReadOnlyCollection<string> values = CMonsterType.GetValues();

            if (!values.Contains(monsterType))
                throw new Exception("未定義のモンスタータイプです。");

            return monsterType;
        }

        public static string MySkillId(string mySkillId)
        {
            string pattern = @"^myskill\d{4}$";

            if (!Regex.IsMatch(mySkillId, pattern))
                throw new Exception(GetMessageNotMatching("マイスキルID"));

            return mySkillId;
        }

        public static string Name(string name)
        {
            int maxLength = 15;

            if (maxLength < name.Length)
                throw new Exception($"名称は{maxLength}文字以内で設定してください。");

            return name;
        }

        public static string ShopId(string shopId)
        {
            string pattern = @"^shop\d{3}$";

            if (!Regex.IsMatch(shopId, pattern))
                throw new Exception(GetMessageNotMatching("ショップID"));

            return shopId;
        }

        public static string ShortName(string shortName)
        {
            int maxLength = 5;

            if (maxLength < shortName.Length)
                throw new Exception($"省略名は{maxLength}文字以内で設定してください。");

            return shortName;
        }

        public static string SkillId(string skillId)
        {
            string pattern = @"^skill\d{3}$";

            if (!Regex.IsMatch(skillId, pattern))
                throw new Exception(GetMessageNotMatching("スキルID"));

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

            string message = GetMessageSetWithinRange("素早さ", min, max);

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
            IReadOnlyCollection<int> values = CTarget.GetValues();

            if (!values.Contains(stateType))
                throw new Exception(_messageUndefinedState);

            return stateType;
        }

        public static int WeekType(int week)
        {
            IReadOnlyCollection<int> values = CElement.GetValues();

            if (!values.Contains(week))
                throw new Exception(_messageUndefinedElement);

            return week;
        }
    }
}