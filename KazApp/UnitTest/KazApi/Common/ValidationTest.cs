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
        [DisplayName("攻撃力 OK")]
        [InlineData(0)]
        [InlineData(255)]
        public void AttackOkTest(int attack)
        {
            Validation.Attack(attack);
        }

        [Theory]
        [DisplayName("攻撃力 NG")]
        [InlineData(-1)]
        [InlineData(256)]
        public void AttackNgTest(int attack)
        {
            Assert.Throws<Exception>(() => Validation.Attack(attack));
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
        [DisplayName("コードID OK")]
        [InlineData("code000")]
        [InlineData("code999")]
        public void CodeIdOkTest(string codeId)
        {
            Validation.CodeId(codeId);
        }

        [Theory]
        [DisplayName("コードID NG")]
        [InlineData("code1111")]
        [InlineData("code11")]
        [InlineData("Code001")]
        [InlineData("codee001")]
        public void CodeIdNgTest(string codeId)
        {
            Assert.Throws<Exception>(() => Validation.CodeId(codeId));
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
        [DisplayName("クリティカル率 OK")]
        [InlineData(0.0)]
        [InlineData(0.1)]
        [InlineData(1.0)]
        public void CriticalOkTest(double critical)
        {
            Validation.Critical(critical);
        }

        [Theory]
        [DisplayName("クリティカル率 NG")]
        [InlineData(-0.1)]
        [InlineData(1.1)]
        public void CriticalNgTest(double critical)
        {
            Assert.Throws<Exception>(() => Validation.Critical(critical));
        }

        [Theory]
        [DisplayName("回避率 OK")]
        [InlineData(0.0)]
        [InlineData(0.1)]
        [InlineData(1.0)]
        public void DodgeOkTest(double dodge)
        {
            Validation.Dodge(dodge);
        }

        [Theory]
        [DisplayName("回避率 NG")]
        [InlineData(-0.1)]
        [InlineData(1.1)]
        public void DodgeNgTest(double dodge)
        {
            Assert.Throws<Exception>(() => Validation.Dodge(dodge));
        }

        [Theory]
        [DisplayName("命中率 OK")]
        [InlineData(0.0)]
        [InlineData(0.1)]
        [InlineData(1.0)]
        public void HitRateOkTest(double hitRate)
        {
            Validation.HitRate(hitRate);
        }

        [Theory]
        [DisplayName("命中率 NG")]
        [InlineData(-0.1)]
        [InlineData(1.1)]
        public void HitRateNgTest(double hitRate)
        {
            Assert.Throws<Exception>(() => Validation.HitRate(hitRate));
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
        [DisplayName("アイテムID OK")]
        [InlineData("item001")]
        [InlineData("item999")]
        [InlineData("aZ001")]
        [InlineData("ZZZaaa001")]
        public void ItemIdOkTest(string itemId)
        {
            Validation.ItemId(itemId);
        }

        [Theory]
        [DisplayName("アイテムID NG")]
        [InlineData("item0011")]
        [InlineData("_item999")]
        [InlineData("Item")]
        [InlineData("001")]
        [InlineData("")]
        public void ItemIdNgTest(string itemId)
        {
            Assert.Throws<Exception>(() => Validation.ItemId(itemId));
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
        [DisplayName("モンスターID OK")]
        [InlineData("monster123")]
        [InlineData("monster999")]
        public void MonsterIdOkTest(string monsterId)
        {
            Validation.MonsterId(monsterId);
        }

        [Theory]
        [DisplayName("モンスターID NG")]
        [InlineData("onster001")]
        [InlineData("Monster001")]
        [InlineData("monster0001")]
        [InlineData("001monster")]
        public void MonsterIdNgTest(string monsterId)
        {
            Assert.Throws<Exception>(() => Validation.MonsterId(monsterId));
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
        [DisplayName("ショップID OK")]
        [InlineData("shop001")]
        [InlineData("shop999")]
        public void ShopIdOkTest(string shopId)
        {
            Validation.ShopId(shopId);
        }

        [Theory]
        [DisplayName("ショップID NG")]
        [InlineData("Shop001")]
        [InlineData("shop0011")]
        [InlineData("shop_011")]
        public void ShopIdNgTest(string shopId)
        {
            Assert.Throws<Exception>(() => Validation.ShopId(shopId));
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
        [DisplayName("スピード OK")]
        [InlineData(0)]
        [InlineData(255)]
        public void SpeedOkTest(int speed)
        {
            Validation.Speed(speed);
        }

        [Theory]
        [DisplayName("スピード NG")]
        [InlineData(-1)]
        [InlineData(256)]
        public void SpeedNgTest(int speed)
        {
            Assert.Throws<Exception>(() => Validation.Speed(speed));
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

        [Theory]
        [DisplayName("弱点タイプ OK")]
        [InlineData(1)]
        [InlineData(5)]
        public void WeekTypeOkTest(int weekType)
        {
            Validation.WeekType(weekType);
        }

        [Theory]
        [DisplayName("ターゲットタイプ NG")]
        [InlineData(-1)]
        [InlineData(100)]
        public void WeekTypeNgTest(int weekType)
        {
            Assert.Throws<Exception>(() => Validation.WeekType(weekType));
        }
    }
}
