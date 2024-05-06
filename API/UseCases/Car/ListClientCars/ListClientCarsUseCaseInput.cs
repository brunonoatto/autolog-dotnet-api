using Microsoft.AspNetCore.Mvc;

namespace AutologApi.API.UseCases
{
    // TODO: depois tentar pegar o ClientId enviado no TokenJWT e deixa-lo como opcional
    public record ListClientCarsUseCaseInput(
        [FromRoute] Guid ClientId,
        [FromQuery] bool Transfereds = false
    );
}
