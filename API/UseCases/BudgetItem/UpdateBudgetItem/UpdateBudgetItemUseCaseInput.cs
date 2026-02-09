using Microsoft.AspNetCore.Mvc;

namespace AutologApi.API.UseCases
{
    public record UpdateBudgetItemUseCaseInputDto(string Description, int Qtd, decimal Price);

    public record UpdateBudgetItemUseCaseInput(
        [FromBody] UpdateBudgetItemUseCaseInputDto BodyData,
        [FromRoute] Guid BudgetId,
        [FromRoute] Guid BudgetItemId
    );
}
