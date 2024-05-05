
using AutologApi.API.Domain.Model;

namespace AutologApi.API.UseCases.Auth
{
    public record CreateUserClientUseCaseInput(string Name, string Email, string Password, string Cpf_Cnpj, string Phone);
}