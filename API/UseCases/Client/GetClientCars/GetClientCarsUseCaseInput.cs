using Microsoft.AspNetCore.Mvc;

namespace AutologApi.API.UseCases
{
    public record GetClientCarsUseCaseInput([FromRoute] Guid ClientId);
}
