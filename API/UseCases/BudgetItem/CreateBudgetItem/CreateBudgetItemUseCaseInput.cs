using Microsoft.AspNetCore.Mvc;

namespace AutologApi.API.UseCases
{
    public record CreateBudgetItemUseCaseInputDto(
        string Id,
        string Description,
        int Qtd,
        decimal Price
    );

    public record CreateBudgetItemUseCaseInput(
        [FromBody] CreateBudgetItemUseCaseInputDto BodyData,
        [FromRoute] Guid BudgetId
    );
}
