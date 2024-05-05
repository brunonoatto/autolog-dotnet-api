
namespace AutologApi.API.UseCases.UserGarage
{
    public record CreateUserGarageUseCaseInput(string Name, string Email, string Password, string Cpf_Cnpj, string Phone, string Address, int AddressNumber, string? Complement);
}