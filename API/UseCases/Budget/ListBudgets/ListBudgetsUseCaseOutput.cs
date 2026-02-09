using AutologApi.API.Domain.Models;

namespace AutologApi.API.UseCases
{
    public record CarUseCaseOutput(string License, Guid ClientId, string Model, int Year);

    public record ListBudgetsUseCaseOutput(
        int Os,
        Guid GarageId,
        string GarageName,
        string? Observation,
        string? ObservationClient,
        string CreatedDate,
        string License,
        BudgetStatusEnum Status,
        string ClientName,
        CarUseCaseOutput Car
    );
}
