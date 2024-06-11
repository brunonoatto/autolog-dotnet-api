using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace AutologApi.API.UseCases
{
    public record NewUserWIthoutLoginInput(string CpfCnpj, string Name, string Phone);

    public record NewCarInput(string License, string Brand, string Model, int Year);

    public record NewBudgetInput(
        Guid? ClientId,
        NewUserWIthoutLoginInput? NewClient,
        Guid? CarId,
        NewCarInput? Car,
        string? Observation
    );

    public record CreateBudgetUseCaseInput([FromBody] NewBudgetInput Body, ClaimsPrincipal User);
}
