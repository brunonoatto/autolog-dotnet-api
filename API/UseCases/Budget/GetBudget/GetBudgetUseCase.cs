using AutologApi.API.Domain.Models;
using AutologApi.API.Infra.Repository;
using Microsoft.EntityFrameworkCore;

namespace AutologApi.API.UseCases
{
    public class GetBudgetUseCase(AppDbContext Repository) : IUseCase<GetBudgetUseCaseInput>
    {
        public async Task<IResult> Execute(GetBudgetUseCaseInput input)
        {
            var isOS = input.OsOrId.All(Char.IsDigit);

            var budget = isOS ? await GetBudgetByOSAsync(input) : await GetById(input.OsOrId);

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

        private async Task<Budget?> GetBudgetByOSAsync(GetBudgetUseCaseInput Input)
        {
            Int32.TryParse(Input.OsOrId, out int Os);

            Guid? garageId =
                Input.User.GetUserType() == UserTypeEnum.Garage ? Input.User.GetGarageId() : null;

            var budget = await Repository
                .Budgets.Include(b => b.Items.Where(i => i.IsEnabled))
                .Include(b => b.Car)
                .Include(b => b.Garage)
                .ThenInclude(g => g!.User)
                .FirstOrDefaultAsync(b =>
                    b.Os == Os && (!garageId.HasValue || b.GarageId == garageId)
                );

            return budget;
        }

        private async Task<Budget?> GetById(string Id)
        {
            Guid.TryParse(Id, out Guid idGuid);

            var budget = await Repository
                .Budgets.Include(b => b.Items.Where(i => i.IsEnabled))
                .Include(b => b.Car)
                .Include(b => b.Garage)
                .ThenInclude(g => g!.User)
                .FirstOrDefaultAsync(b => b.Id == idGuid);

            return budget;
        }
    }
}
