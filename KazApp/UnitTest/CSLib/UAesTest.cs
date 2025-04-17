using CSLib.Lib;
using Xunit.Abstractions;

namespace UnitTest
{
    public class UAesTest
    {
        private readonly ITestOutputHelper _output;

        public UAesTest(ITestOutputHelper output)
        {
            _output = output;
        }

        [Theory(DisplayName = "文字列の暗号化")]
        [InlineData("")]
        [InlineData("TEST")]
        [InlineData("password")]
        public void UT001(string data)
        {
            string result = UAes.AesEncrypt(data);

            if (data == "")
                Assert.Equal("tVIs1T89WnKMXFMUdO/BUA==", result);
            else if (data == "TEST")
                Assert.Equal("3oFwSxo1m5GO/3aOolfZag==", result);
            else if (data == "password")
                Assert.Equal("cf8kVC++g3aN9Uox/7mASw==", result);
        }

        [Theory(DisplayName = "文字列の復号化")]
        [InlineData("tVIs1T89WnKMXFMUdO/BUA==")] // ""
        [InlineData("3oFwSxo1m5GO/3aOolfZag==")] // TEST
        [InlineData("cf8kVC++g3aN9Uox/7mASw==")] // password
        public void UT002(string data)
        {
            string result = UAes.AesDecrypt(data);

            if (data == "tVIs1T89WnKMXFMUdO/BUA==")
                Assert.Equal("", result);
            else if (data == "3oFwSxo1m5GO/3aOolfZag==")
                Assert.Equal("TEST", result);
            else if (data == "cf8kVC++g3aN9Uox/7mASw==")
                Assert.Equal("password", result);
        }
    }
}