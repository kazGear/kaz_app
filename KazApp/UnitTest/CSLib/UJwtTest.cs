
using CSLib.Lib;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Configuration;
using NuGet.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Text.RegularExpressions;
using UnitTest.Mock;
using Xunit.Abstractions;

namespace UnitTest.Lib
{
    public class UJwtTest : IClassFixture<MockAppSettingsFixture>
    {
        private readonly ITestOutputHelper _output;
        private readonly IConfiguration _configuration;

        public UJwtTest(ITestOutputHelper output, MockAppSettingsFixture appsettings)
        {
            _output = output;
            _configuration = appsettings.Configuration;
        }

        [Theory(DisplayName = "Json Web Tokenの発行")]
        [InlineData("Pass-word")]
        [InlineData("PASS_WORD")]
        [InlineData("pass")]
        public void UT001(string pass)
        {
            string jwt = UJwt.GenerateJwtToken(pass, _configuration);

            string pattern = "[\\w-]+.[\\w-]+.[\\w-]+";
            bool isMatch = Regex.IsMatch(jwt, pattern);

            Assert.True(isMatch);
            Assert.True(jwt.Length > 200);
        }

        [Theory(DisplayName = "jwt属性値検証")]
        [InlineData("userName")]
        public void UT004(string data)
        {
            string jwt = UJwt.GenerateJwtToken(data, _configuration);

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken? token = handler.ReadToken(jwt) as JwtSecurityToken;

            Assert.True(token!.Subject == "user authentication for kazApp.");
            Assert.True(token!.Issuer == "kazApp");
            Assert.True(token!.Audiences.First() == "kazAppUi"); // 複数のAudiencesがありえる
        }
    }
}
