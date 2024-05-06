namespace AutologApi.API.UseCases
{
    // TODO: receber o ClientId pelo token
    public record CreateCarUseCaseInput(Guid ClientId, string License, string Brand, string Model, int Year);
}