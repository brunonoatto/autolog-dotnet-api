using AutologApi.API.Domain.Models;
using AutologApi.API.Infra.Repository;
using Microsoft.EntityFrameworkCore;

namespace AutologApi.API.UseCases
{
    public class GetBudgetUseCase(AppDbContext Repository) : IUseCase<GetBudgetUseCaseInput>
    {
        public async Task<IResult> Execute(GetBudgetUseCaseInput input)
        {
            Guid? garageId =
                input.User.GetUserType() == UserTypeEnum.Garage ? input.User.GetGarageId() : null;

            var budget = await Repository
                .Budgets.Include(b => b.Items.Where(i => i.IsEnabled))
                .Include(b => b.Car)
                .Include(b => b.Garage)
                .ThenInclude(g => g!.User)
                .FirstOrDefaultAsync(b =>
                    b.Os == input.Os && (!garageId.HasValue || b.GarageId == garageId)
                );

            if (budget is null)
            {
                return Results.NotFound("Orçamento não encontrado");
            }

            var budgetOutput = new GetBudgetUseCaseOutput(
                budget.Id,
                budget.Os,
                budget.GarageId,
                budget.Car!.License,
                budget.Status,
                budget.UserId,
                budget.Observation,
                budget.CreatedDate.ToShortDateString(),
                budget.Garage!.User!.Name,
                budget.Car,
                budget.Items
            );

            return Results.Ok(budgetOutput);
        }
    }
}
