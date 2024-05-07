namespace AutologApi.API.UseCases
{
    public record CreateBudgetUseCaseInput(
        Guid GarageId,
        Guid ClientId,
        Guid CarId,
        string Observation
    );
}
