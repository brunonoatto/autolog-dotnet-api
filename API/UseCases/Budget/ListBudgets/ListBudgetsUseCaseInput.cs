using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace AutologApi.API.UseCases
{
    public record ListBudgetsUseCaseInput([FromQuery] string license, ClaimsPrincipal User);
}
