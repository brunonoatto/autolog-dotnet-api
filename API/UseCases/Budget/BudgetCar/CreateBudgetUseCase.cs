using AutologApi.API.Domain.Models;
using AutologApi.API.Infra.Repository;

namespace AutologApi.API.UseCases
{
    public class CreateBudgetUseCase(AppDbContext Repository) : IUseCase<CreateBudgetUseCaseInput>
    {
        public async Task<IResult> Execute(CreateBudgetUseCaseInput input)
        {
            var newBudget = new Budget
            {
                GarageId = input.GarageId,
                ClientId = input.ClientId,
                CarId = input.CarId,
                Status = BudgetStatusEnum.MakingBudget,
                Observation = input.Observation,
            };

            await Repository.Budgets.AddAsync(newBudget);
            Repository.SaveChanges();

            return Results.Ok(newBudget);
        }
    }
}
