namespace AutologApi.API.UseCases
{
    public record UpdateBudgetItemUseCaseOutput(
        string Id,
        string Os,
        string Description,
        int Qtd,
        int Price
    );
}
