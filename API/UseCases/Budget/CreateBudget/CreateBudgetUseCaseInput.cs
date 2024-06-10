using System.Security.Claims;

namespace AutologApi.API.UseCases
{
    public record NewUserWIthoutLogin(string CpfCnpj, string Name, string Phone);

    public record NewCar(string License, string Brand, string Model, int Year);

    public record CreateBudgetUseCaseInput(
        Guid? ClientId,
        NewUserWIthoutLogin? NewClient,
        Guid? CarId,
        NewCar? Car,
        string? Observation,
        ClaimsPrincipal User
    );
}
