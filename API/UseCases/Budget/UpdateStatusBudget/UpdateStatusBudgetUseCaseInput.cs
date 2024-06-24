using Microsoft.AspNetCore.Mvc;

namespace AutologApi.API.UseCases
{
    public record UpdateStatusBudgetUseCaseInput(
        [FromRoute] Guid BudgetId,
        [FromBody] string? ObservationClient
    );
}
