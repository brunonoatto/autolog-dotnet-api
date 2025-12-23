using AutologApi.API.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace AutologApi.API.Endpoints.Client
{
    public static class ClientEndpoints
    {
        public static void MapClientEndpoints(this IEndpointRouteBuilder app)
        {
            var clientGroup = app.MapGroup("client");

            clientGroup.MapGet("/", GetClient);
            clientGroup.MapGet("/{clientId}/cars", GetClientCars);
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
