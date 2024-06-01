using Microsoft.AspNetCore.Mvc;

namespace AutologApi.API.UseCases
{
    public record DeleteBudgetItemUseCaseInput([FromRoute] Guid BudgetItemId);
}
