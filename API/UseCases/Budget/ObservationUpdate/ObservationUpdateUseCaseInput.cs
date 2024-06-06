using Microsoft.AspNetCore.Mvc;

namespace AutologApi.API.UseCases
{
    public record ObservationUpdateUseCaseInputData(string Observation);

    public record ObservationUpdateUseCaseInput(
        [FromRoute] Guid BudgetId,
        [FromBody] ObservationUpdateUseCaseInputData Data
    );
}
