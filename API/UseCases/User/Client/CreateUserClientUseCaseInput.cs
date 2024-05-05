
namespace AutologApi.API.UseCases
{
    public record CreateUserClientUseCaseInput(string Name, string Email, string Password, string Cpf_Cnpj, string Phone);
}