using AutologApi.API.Domain.Models;
using AutologApi.API.Infra.Repository;
using Microsoft.EntityFrameworkCore;

namespace AutologApi.API.UseCases
{
    public class ObservationUpdateUseCase(AppDbContext Repository)
        : IUseCase<ObservationUpdateUseCaseInput>
    {
        public BudgetStatusEnum NewStatus { get; set; } = BudgetStatusEnum.None;

        public async Task<IResult> Execute(ObservationUpdateUseCaseInput input)
        {
            var budget = await Repository.Budgets.FirstOrDefaultAsync(b => b.Id == input.BudgetId);

            if (budget == null)
            {
                return Results.BadRequest("Orçamento não encontrado.");
            }

            budget.Observation = input.Data.Observation;

            Repository.Budgets.Update(budget);
            await Repository.SaveChangesAsync();

            return Results.Ok();
        }
    }
}
