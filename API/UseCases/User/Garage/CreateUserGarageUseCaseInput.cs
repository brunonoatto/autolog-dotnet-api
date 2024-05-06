namespace AutologApi.API.UseCases
{
    public record CreateUserGarageUseCaseInput(
        string Name,
        string Email,
        string Password,
        string Cpf_Cnpj,
        string Phone,
        string Address,
        int AddressNumber,
        string? Complement
    );
}
