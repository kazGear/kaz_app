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
        public void AttackNg(int attack)
        {
            Assert.Throws<Exception>(() => Validation.Attack(attack));
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
    }
}
