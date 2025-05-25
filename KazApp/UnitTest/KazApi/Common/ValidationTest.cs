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
        public void UT001(int amount)
        {
            Validation.Amount(amount);
        }

        [Theory]
        [DisplayName("金額 NG")]
        [InlineData(-1)]
        public void UT002(int amount)
        {
            Assert.Throws<Exception>(() => Validation.Amount(amount));
        }

        [Theory]
        [DisplayName("攻撃力 OK")]
        [InlineData(0)]
        [InlineData(255)]
        public void UT003(int attack)
        {
            Validation.Attack(attack);
        }

        [Theory]
        [DisplayName("攻撃力 NG")]
        [InlineData(-1)]
        [InlineData(256)]
        public void UT004(int attack)
        {
            Assert.Throws<Exception>(() => Validation.Attack(attack));
        }

        [Theory]
        [DisplayName("コードID OK")]
        [InlineData("code000")]
        [InlineData("code999")]
        public void UT005(string codeId)
        {
            Validation.CodeId(codeId);
        }

        [Theory]
        [DisplayName("コードID NG")]
        [InlineData("code1111")]
        [InlineData("code11")]
        [InlineData("Code001")]
        [InlineData("codee001")]
        public void UT006(string codeId)
        {
            Assert.Throws<Exception>(() => Validation.CodeId(codeId));
        }

        [Theory]
        [DisplayName("コード値 OK")]
        [InlineData(0)]
        [InlineData(99)]
        public void UT007(int codeValue)
        {
            Validation.CodeValue(codeValue);
        }

        [Theory]
        [DisplayName("コード値 NG")]
        [InlineData(-1)]
        [InlineData(100)]
        public void UT008(int codeValue)
        {
            Assert.Throws<Exception>(() => Validation.CodeValue(codeValue)); 
        }
    }
}
