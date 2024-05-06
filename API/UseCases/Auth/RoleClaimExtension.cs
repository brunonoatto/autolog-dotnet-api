using System.Security.Claims;
using AutologApi.API.Domain.Models;

public static class RoleClaimExtention
{
    public static IEnumerable<Claim> GetClaims(this User user)
    {
        var result = new List<Claim>
        {
            new("name", user.Name),
            new(ClaimTypes.Email, user.Email),
            new("type", user.Type.ToString()),
        };
        return result;
    }
}
