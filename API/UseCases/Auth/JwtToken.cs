using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace AutologApi.API.UseCases
{
    // public class TokenService(AppSettings AppSettings)
    public class TokenService()
    {
        public static string SecretByte = "5+IV)E2glD3xCH2rNTElZ_at9(TbG1N(E=pH)29*";

        public string Generate(TokenData tokenData)
        {
            var handler = new JwtSecurityTokenHandler();
            // var key = Encoding.ASCII.GetBytes(AppSettings.Hash.JwtKey);
            var key = Encoding.ASCII.GetBytes(SecretByte);
            var credentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature
            );

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(tokenData.GetClaims()),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = credentials,
            };
            var token = handler.CreateToken(tokenDescriptor);
            return handler.WriteToken(token);
        }
    }
}
