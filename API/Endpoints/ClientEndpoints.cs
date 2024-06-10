using AutologApi.API.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace AutologApi.API.Endpoints.Client
{
    public static class ClientEndpoints
    {
        public static WebApplication MapClientEndpoints(this WebApplication app)
        {
            var clientGroup = app.MapGroup("client");

            clientGroup.MapGet("/", GetClient);
            clientGroup.MapGet("/{clientId}/cars", GetClientCars);

            return app;
        }

        private static Task<IResult> GetClient(
            [AsParameters] GetClientUseCaseInput input,
            [FromServices] GetClientUseCase useCase
        )
        {
            return useCase.Execute(input);
        }

        private static Task<IResult> GetClientCars(
            [AsParameters] GetClientCarsUseCaseInput input,
            [FromServices] GetClientCarsUseCase useCase
        )
        {
            return useCase.Execute(input);
        }
    }
}
