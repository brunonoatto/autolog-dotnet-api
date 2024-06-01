using AutologApi.API.Domain.Models;
using AutologApi.API.Infra.Repository;
using Microsoft.EntityFrameworkCore;

namespace AutologApi.API.UseCases
{
    public class UpdateStatusBudgetUseCase(AppDbContext Repository)
        : IUseCase<UpdateStatusBudgetUseCaseInput>
    {
        public BudgetStatusEnum NewStatus { get; set; } = BudgetStatusEnum.None;

        public async Task<IResult> Execute(UpdateStatusBudgetUseCaseInput input)
        {
            if (NewStatus == BudgetStatusEnum.None)
            {
                return Results.BadRequest("Novo status não informado.");
            }

            var budget = await Repository.Budgets.FirstOrDefaultAsync(b => b.Id == input.BudgetId);

            if (budget == null)
            {
                return Results.BadRequest("Orçamento não encontrado.");
            }

            budget.Status = NewStatus;

            Repository.Budgets.Update(budget);
            await Repository.SaveChangesAsync();

            return Results.Ok();
        }
    }
}
