namespace AutologApi.API.UseCases
{
    public record CreateBudgetItemUseCaseOutput(
        string Id,
        string Os,
        string Description,
        int Qtd,
        int Price
    );
}
