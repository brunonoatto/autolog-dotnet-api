using Microsoft.AspNetCore.Mvc;

namespace AutologApi.API.UseCases
{
    public record BudgetItemUseCaseInput(string Id, string Description, int Qtd, int Price);

    public record CreateBudgetItemUseCaseInput(
        [FromBody] BudgetItemUseCaseInput BodyData,
        [FromRoute] Guid BudgetId
    );
}
