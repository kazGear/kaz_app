using KazApi.Domain._Const;
using System.Text.RegularExpressions;

namespace KazApi.Common._Filter
{
    public static class Validation
    {
        private static readonly string _messageUndefinedElement = "定義されていない属性です。";
        private static readonly string _messageUndefinedSkill = "定義されていないスキルです。";
        private static readonly string _messageUndefinedState = "定義されていない状態です。";
        private static readonly int _maxLengthName = 10;

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

        public static string MonsterId(string monsterId)
        {
            string pattern = @"^monster\d{3}$";

            if (!Regex.IsMatch(monsterId, pattern))
                throw new Exception("モンスターIDのパターンが異なります。");

            return monsterId;
        }

        public static string MonsterName(string monsterName)
        {
            if (_maxLengthName < monsterName.Length)
                throw new Exception($"モンスター名は{_maxLengthName}文字以内にしてください。");

            return monsterName;
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

        public static string SkillName(string skillName)
        {
            if (_maxLengthName < skillName.Length)
                throw new Exception($"モンスター名は{_maxLengthName}文字以内にしてください。");

            return skillName;
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
