using System.Security.Claims;
using AutologApi.API.Domain.Models;
using AutologApi.API.UseCases.Auth;

namespace AutologApi.API.UseCases
{
    public static class IdentityExtention
    {
        private static string GetFieldValue(this ClaimsPrincipal claims, string types)
        {
            var claimsIdentity = claims.Identity as ClaimsIdentity;
            var claim = claimsIdentity?.FindFirst(types);

            if (claim == null)
                throw new Exception("Field não enconstrado");

            return claim.Value;
        }

        public static Guid GetUserId(this ClaimsPrincipal claims)
        {
            var typeValue = claims.GetFieldValue(CustomClaimTypes.Id);

            return new Guid(typeValue);
        }

        public static UserTypeEnum GetUserType(this ClaimsPrincipal claims)
        {
            var typeValue = claims.GetFieldValue(CustomClaimTypes.Type);

            if (!Enum.TryParse(typeValue, out UserTypeEnum userType))
                throw new Exception("Tipo do usuário não encontrado.");

            return userType;
        }

        public static Guid GetGarageId(this ClaimsPrincipal claims)
        {
            var userType = claims.GetUserType();

            if (userType != UserTypeEnum.Garage)
                throw new Exception("Tipo do usuário inválido.");

            return GetUserId(claims);
        }

        public static Guid GetClientId(this ClaimsPrincipal claims)
        {
            var userType = claims.GetUserType();

            if (userType != UserTypeEnum.Client)
                throw new Exception("Tipo do usuário inválido.");

            return GetUserId(claims);
        }
    }
}
