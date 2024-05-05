using Microsoft.AspNetCore.Mvc;

namespace AutologApi.API.UseCases
{
    public record ListClientCarsUseCaseInput([FromQuery] Guid ClientId, [FromQuery] bool Transfereds);
}