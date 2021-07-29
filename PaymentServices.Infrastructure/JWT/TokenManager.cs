using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PaymentServices.Infrastructure.JWT
{
    public static class TokenManager
    {
        public static string GenerateAccessToken(int userId, string Key)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, Convert.ToString(userId))
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public static int ReadAccessToken(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var dynaToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

                var jwtClaims = dynaToken.Claims.First(claim => claim.Type == "unique_name");

                if (jwtClaims != null) return int.Parse(jwtClaims.Value);
            }
            catch (Exception)
            {
                //Log exception in future
            }

            return 0;
        }
    }
}
