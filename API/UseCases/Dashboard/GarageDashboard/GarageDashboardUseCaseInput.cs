using System.Security.Claims;

namespace AutologApi.API.UseCases
{
    public record GarageDashboardUseCaseInput(ClaimsPrincipal User);
}
