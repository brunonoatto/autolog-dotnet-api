using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutologApi.API.Domain.Model;
using Microsoft.IdentityModel.Tokens;

namespace AutologApi.API.UseCases.Auth
{
    public static class TokenService
    {
        public static string Generate(User user)
        {
            var handler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.JwtKey);
            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(user.GetClaims()),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = credentials,
            };
            var token = handler.CreateToken(tokenDescriptor);
            return handler.WriteToken(token);
        }
    }
    // public static class TokenService
    // {
    //     public static string GenerateToken(User user)
    //     {
    //         Console.WriteLine("-----1");
    //         var tokenHandler = new JwtSecurityTokenHandler();
    //         Console.WriteLine("2");
    //         var key = Encoding.ASCII.GetBytes(Settings.JwtKey);
    //         Console.WriteLine("4");
    //         var tokenDescriptor = new SecurityTokenDescriptor
    //         {
    //             Subject = new ClaimsIdentity(user.GetClaims()),
    //             Expires = DateTime.UtcNow.AddDays(1),
    //             SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
    //         };
    //         Console.WriteLine(tokenDescriptor.ToString());
    //         var token = tokenHandler.CreateToken(tokenDescriptor);
    //         Console.WriteLine("9");
    //         return tokenHandler.WriteToken(token);
    //     }
    // }
}