using Microsoft.AspNetCore.Mvc;

namespace AutologApi.API.UseCases
{
    // TODO: é obrigatório enviar Cpf_Cnppj ou Email, fazer um validator depois, ou se conseguir configurar aqui
    public record GetClientUseCaseInput(
        [FromQuery] string? CpfCnpj,
        [FromQuery] string? Email,
        [FromQuery] bool WithCars = false
    );
}
