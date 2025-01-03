﻿using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace CSLib.Lib
{
    /// <summary>
    /// Json Web Token Util
    /// </summary>
    public class UJwt
    {
        /// <summary>
        /// Json Web Token の発行
        /// </summary>
        public static string GenerateJwtToken(string userName, IConfiguration configuration)
        {
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            DateTime now = DateTime.UtcNow; // 基準時刻

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, userName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: claims,
                notBefore: now,
                expires: DateTime.UtcNow.AddDays(Convert.ToDouble(configuration["Jwt:ExpireDays"])),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        /// <summary>
        /// トークンが有効か確認
        /// true: 有効, false: 無効
        /// </summary>
        public static bool IsValidToken(string token)
        {
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            // トークンデコード
            JwtSecurityToken? jwtToken = null;
            try
            {
                jwtToken = handler.ReadToken(token) as JwtSecurityToken;
                if (jwtToken == null) return false;
            }
            catch (Exception)
            {
                return false;
            }

            // 有効期限
            DateTime limit = jwtToken!.ValidTo;
            DateTime now = DateTime.UtcNow;

            // 期限比較
            if (limit < now) return false;
            return true;
        }
    }
}
