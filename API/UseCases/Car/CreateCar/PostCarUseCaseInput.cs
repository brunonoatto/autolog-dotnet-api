namespace AutologApi.API.UseCases
{
    // TODO: receber o ClientId pelo token
    public record PostCarUseCaseInput(Guid ClientId, string License, string Brand, string Model, int Year);
}