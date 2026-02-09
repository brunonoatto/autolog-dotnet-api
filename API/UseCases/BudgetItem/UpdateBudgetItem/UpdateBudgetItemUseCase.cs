using AutologApi.API.Infra.Repository;

namespace AutologApi.API.UseCases
{
    public class UpdateBudgetItemUseCase(AppDbContext Repository)
        : IUseCase<UpdateBudgetItemUseCaseInput>
    {
        public async Task<IResult> Execute(UpdateBudgetItemUseCaseInput input)
        {
            var bodyData = input.BodyData;
            var budgetId = input.BudgetId;
            var budgetItemId = input.BudgetItemId;

            var item = Repository.BudgetItems.Find(budgetItemId);

            if (item == null)
            {
                return Results.BadRequest("Item não encontrado.");
            }

            if (item.BudgetId != budgetId)
            {
                return Results.BadRequest("O item não pertence ao orçamento informado.");
            }

            item.Description = bodyData.Description;
            item.Qtd = bodyData.Qtd;
            item.Price = bodyData.Price;

            Repository.BudgetItems.Update(item);
            await Repository.SaveChangesAsync();

            return Results.Ok(item);
        }
    }
}
