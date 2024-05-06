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

            return app;
        }

        private static Task<IResult> GetClient([AsParameters] GetClientUseCaseInput input, [FromServices] GetClientUseCase getClientUseCase)
        {
            return getClientUseCase.Execute(input);
        }
    }
}