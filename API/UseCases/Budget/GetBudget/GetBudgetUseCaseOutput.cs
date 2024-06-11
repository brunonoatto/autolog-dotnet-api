using AutologApi.API.Domain.Models;

namespace AutologApi.API.UseCases
{
    public record GetBudgetUseCaseOutput(
        Guid Id,
        int Os,
        Guid GarageId,
        string License,
        BudgetStatusEnum Status,
        Guid ClientId,
        string? Observation,
        string CreatedDate,
        string GarageName,
        Car Car,
        ICollection<BudgetItem> Items
    );
}
