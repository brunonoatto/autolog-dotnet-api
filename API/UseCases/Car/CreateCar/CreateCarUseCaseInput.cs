using System.Security.Claims;

namespace AutologApi.API.UseCases
{
    public record CreateCarUseCaseInput(
        string License,
        string Brand,
        string Model,
        int Year,
        ClaimsPrincipal User
    );
}
