using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace AutologApi.API.UseCases
{
    public record GetBudgetUseCaseInput([FromRoute] int Os, ClaimsPrincipal User);
}
