namespace AutologApi.API.UseCases
{
    public record GarageDashboardUseCaseOutput(
        int Os,
        int Status,
        string? Observation,
        string License,
        string Brand,
        string Model,
        int Year,
        string ClientName
    );
}
