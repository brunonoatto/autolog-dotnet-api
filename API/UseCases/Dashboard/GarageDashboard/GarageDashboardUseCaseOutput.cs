namespace AutologApi.API.UseCases
{
    public record GarageDashboardUseCaseOutput(
        int Os,
        int Status,
        string? Observation,
        string License,
        string Model,
        int Year,
        string ClientName
    );
}
