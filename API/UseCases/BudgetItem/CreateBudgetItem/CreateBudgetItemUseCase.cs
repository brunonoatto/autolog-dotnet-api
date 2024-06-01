using AutologApi.API.Domain.Models;
using AutologApi.API.Infra.Repository;

namespace AutologApi.API.UseCases
{
    public class CreateBudgetItemUseCase(AppDbContext Repository)
        : IUseCase<CreateBudgetItemUseCaseInput>
    {
        public async Task<IResult> Execute(CreateBudgetItemUseCaseInput input)
        {
            var bodyData = input.BodyData;
            var budgetId = input.BudgetId;

            var hasItemDescription = Repository.BudgetItems.Any(i =>
                i.IsEnabled && i.BudgetId == budgetId && i.Description == bodyData.Description
            );

            if (hasItemDescription)
            {
                return Results.Conflict("Já existe um item com esta descrição no orçamento.");
            }

            var newBudgetItem = new BudgetItem()
            {
                BudgetId = budgetId,
                Description = bodyData.Description,
                Qtd = bodyData.Qtd,
                Price = bodyData.Price
            };

            await Repository.BudgetItems.AddAsync(newBudgetItem);
            await Repository.SaveChangesAsync();

            return Results.Ok(newBudgetItem);
        }
    }
}
