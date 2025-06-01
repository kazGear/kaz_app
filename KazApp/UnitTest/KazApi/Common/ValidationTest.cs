using KazApi.Common._Filter;
using System.ComponentModel;

namespace UnitTest.KazApi.Common
{
    public class ValidationTest
    {
        [Theory]
        [DisplayName("金額 OK")]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(999999999)]
        public void AmountOkTest(int amount)
        {
            Validation.Amount(amount);
        }

        [Theory]
        [DisplayName("金額 NG")]
        [InlineData(-1)]
        public void AmountNgTest(int amount)
        {
            Assert.Throws<Exception>(() => Validation.Amount(amount));
        }

        [Theory]
        [DisplayName("バトルレポートの連番 OK")]
        [InlineData(1)]
        [InlineData(6)]
        public void BattleReportSerialOkTest(int serial)
        {
            Validation.BattleReportSerial(serial);
        }

        [Theory]
        [DisplayName("バトルレポートの連番 NG")]
        [InlineData(0)]
        [InlineData(7)]
        public void BattleReportSerialNgTest(int serial)
        {
            Assert.Throws<Exception>(() => Validation.BattleReportSerial(serial));
        }

        [Theory]
        [DisplayName("コード値 OK")]
        [InlineData(0)]
        [InlineData(99)]
        public void CodeValueOkTest(int codeValue)
        {
            Validation.CodeValue(codeValue);
        }

        [Theory]
        [DisplayName("コード値 NG")]
        [InlineData(-1)]
        [InlineData(100)]
        public void CodeValueNgTest(int codeValue)
        {
            Assert.Throws<Exception>(() => Validation.CodeValue(codeValue)); 
        }

        [Theory]
        [DisplayName("カウント OK")]
        [InlineData(0)]
        [InlineData(999999999)]
        public void CountOkTest(int count)
        {
            Validation.Count(count);
        }

        [Theory]
        [DisplayName("カウント NG")]
        [InlineData(-1)]
        public void CountNgTest(int count)
        {
            Assert.Throws<Exception>(() => Validation.Count(count));
        }


        [Theory]
        [DisplayName("属性 OK")]
        [InlineData(1)]
        [InlineData(5)]
        public void ElementOkTest(int weekType)
        {
            Validation.ElementType(weekType);
        }

        [Theory]
        [DisplayName("属性 NG")]
        [InlineData(-1)]
        [InlineData(100)]
        public void ElementNgTest(int weekType)
        {
            Assert.Throws<Exception>(() => Validation.ElementType(weekType));
        }

        [Theory]
        [DisplayName("割合 OK")]
        [InlineData(0.0)]
        [InlineData(0.1)]
        [InlineData(1.0)]
        public void RateOkTest(double hitRate)
        {
            Validation.Rate(hitRate);
        }

        [Theory]
        [DisplayName("割合 NG")]
        [InlineData(-0.1)]
        [InlineData(1.1)]
        public void HitRateNgTest(double hitRate)
        {
            Assert.Throws<Exception>(() => Validation.Rate(hitRate));
        }

        [Theory]
        [DisplayName("HP OK")]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(999)]
        public void HpOkTest(int hp)
        {
            Validation.Hp(hp);
        }

        [Theory]
        [DisplayName("命中率 NG")]
        [InlineData(-1)]
        [InlineData(1000)]
        public void HpNgTest(int hp)
        {
            Assert.Throws<Exception>(() => Validation.Hp(hp));
        }

        [Theory]
        [DisplayName("ID OK")]
        [InlineData("item001")]
        [InlineData("item999")]
        [InlineData("skill999")]
        [InlineData("monster999")]
        public void IdOkTest(string id)
        {
            Validation.Id(id);
        }

        [Theory]
        [DisplayName("ID NG")]
        [InlineData("item0011")]
        [InlineData("_item999")]
        [InlineData("Item")]
        [InlineData("001")]
        [InlineData("")]
        public void IdNgTest(string id)
        {
            Assert.Throws<Exception>(() => Validation.Id(id));
        }

        [Theory]
        [DisplayName("ログインID OK")]
        [InlineData("user")]
        [InlineData("_user_")]
        [InlineData("-user-")]
        [InlineData("User001")]
        [InlineData("001User")]
        [InlineData("123456789012345")]
        public void LoginIdOkTest(string loginId)
        {
            Validation.LoginId(loginId);
        }

        [Theory]
        [DisplayName("ログイン NG")]
        [InlineData("123")]
        [InlineData("1234567890123456")]
        [InlineData("ゆーざー")]
        [InlineData("ユーザー")]
        public void LoginIdNgTest(string itemId)
        {
            Assert.Throws<Exception>(() => Validation.LoginId(itemId));
        }

        [Theory]
        [DisplayName("モンスタータイプ OK")]
        [InlineData("monsterType001")]
        [InlineData("monsterType002")]
        public void MonsterTypeOkTest(string monsterType)
        {
            Validation.MonsterType(monsterType);
        }

        [Theory]
        [DisplayName("モンスタータイプ NG")]
        [InlineData("monsterType")]
        public void MonsterTypeNgTest(string monsterType)
        {
            Assert.Throws<Exception>(() => Validation.MonsterType(monsterType));
        }

        [Theory]
        [DisplayName("マイスキルID OK")]
        [InlineData("myskill0001")]
        [InlineData("myskill9999")]
        public void MySkillIdOkTest(string mySkillId)
        {
            Validation.MySkillId(mySkillId);
        }

        [Theory]
        [DisplayName("マイスキルID NG")]
        [InlineData("Myskill0001")]
        [InlineData("mySkill0001")]
        [InlineData("myskill00001")]
        [InlineData("0001myskill")]
        public void MySkillIdNgTest(string mySkillId)
        {
            Assert.Throws<Exception>(() => Validation.MySkillId(mySkillId));
        }

        [Theory]
        [DisplayName("名称 OK")]
        [InlineData("userName")]
        [InlineData("123456789012345")]
        [InlineData("ユーザー名ユーザー名ユーザー名")]
        [InlineData("!#$%&'-^|\\_,./")]
        public void NameOkTest(string name)
        {
            Validation.Name(name);
        }

        [Theory]
        [DisplayName("マイスキルID NG")]
        [InlineData("12345667890123456")]
        public void NameNgTest(string name)
        {
            Assert.Throws<Exception>(() => Validation.Name(name));
        }

        [Theory]
        [DisplayName("省略名 OK")]
        [InlineData("略")]
        [InlineData("ryaku")]
        public void ShortNameOkTest(string shortName)
        {
            Validation.ShortName(shortName);
        }

        [Theory]
        [DisplayName("省略名 NG")]
        [InlineData("省略名６文字")]
        public void ShortNameNgTest(string shortName)
        {
            Assert.Throws<Exception>(() => Validation.ShortName(shortName));
        }

        [Theory]
        [DisplayName("スキルタイプ OK")]
        [InlineData(1)]
        [InlineData(8)]
        public void SkillTypeOkTest(int skillType)
        {
            Validation.SkillType(skillType);
        }

        [Theory]
        [DisplayName("スキルタイプ NG")]
        [InlineData(-1)]
        [InlineData(100)]
        public void SkillTypeNgTest(int skillType)
        {
            Assert.Throws<Exception>(() => Validation.SkillType(skillType));
        }

        [Theory]
        [DisplayName("状態タイプ OK")]
        [InlineData(1)]
        [InlineData(9)]
        public void StateTypeOkTest(int stateType)
        {
            Validation.StateType(stateType);
        }

        [Theory]
        [DisplayName("状態タイプ NG")]
        [InlineData(-1)]
        [InlineData(100)]
        public void StateTypeNgTest(int stateType)
        {
            Assert.Throws<Exception>(() => Validation.StateType(stateType));
        }

        [Theory]
        [DisplayName("強さ OK")]
        [InlineData(0)]
        [InlineData(255)]
        public void StrengthOkTest(int speed)
        {
            Validation.Strength(speed);
        }

        [Theory]
        [DisplayName("強さ NG")]
        [InlineData(-1)]
        [InlineData(256)]
        public void StrengthNgTest(int speed)
        {
            Assert.Throws<Exception>(() => Validation.Strength(speed));
        }

        [Theory]
        [DisplayName("ターゲットタイプ OK")]
        [InlineData(1)]
        [InlineData(8)]
        public void TargetTypeOkTest(int targetType)
        {
            Validation.TargetType(targetType);
        }

        [Theory]
        [DisplayName("ターゲットタイプ NG")]
        [InlineData(-1)]
        [InlineData(100)]
        public void TargetTypeNgTest(int targetType)
        {
            Assert.Throws<Exception>(() => Validation.TargetType(targetType));
        }
    }
}
