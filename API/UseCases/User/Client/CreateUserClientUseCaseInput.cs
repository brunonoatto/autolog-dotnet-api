namespace AutologApi.API.UseCases
{
    public record CreateUserClientUseCaseInput(
        string Name,
        string Email,
        string Password,
        string CpfCnpj,
        string Phone
    );
}
