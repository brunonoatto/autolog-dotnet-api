namespace AutologApi.API.UseCases
{
    public record NewUserWIthoutLogin(string CpfCnpj, string Name, string Phone);

    public record NewCar(string License, string Brand, string Model, int Year);

    // TODO: depois pegar o GarageId do token enviado no request
    public record CreateBudgetUseCaseInput(
        Guid GarageId,
        Guid? ClientId,
        NewUserWIthoutLogin? NewClient,
        Guid? CarId,
        NewCar? Car,
        string? Observation
    );
}
