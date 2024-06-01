using System.Security.Claims;
using AutologApi.API.Domain.Models;
using AutologApi.API.UseCases.Auth;

namespace AutologApi.API.UseCases
{
    public class TokenData(string Id, string Name, UserTypeEnum Type)
    {
        public IEnumerable<Claim> GetClaims()
        {
            var result = new List<Claim>
            {
                new(CustomClaimTypes.Id, Id),
                new(CustomClaimTypes.Name, Name),
                new(CustomClaimTypes.Type, Type.ToString()),
            };

            return result;
        }
    }
}
