using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace AutologApi.API.UseCases
{
    public record CarUseCaseInput(string License, string Model, int Year);

    public record CreateCarUseCaseInput([FromBody] CarUseCaseInput Car, ClaimsPrincipal User);
}
