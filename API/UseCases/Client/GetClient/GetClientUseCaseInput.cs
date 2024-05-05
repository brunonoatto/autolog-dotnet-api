
using Microsoft.AspNetCore.Mvc;

namespace AutologApi.API.UseCases
{
    public record GetClientUseCaseInput([FromQuery] string Cpf_Cnppj, [FromQuery] string Email, [FromQuery] bool WithCars);
}