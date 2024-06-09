using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace AutologApi.API.UseCases
{
    // TODO: depois tentar pegar o ClientId enviado no TokenJWT e deixa-lo como opcional
    public record ListClientCarsUseCaseInput(
        ClaimsPrincipal User,
        [FromQuery] Guid? ClientId = null,
        [FromQuery] bool Transfereds = false
    );
}
