using AutologApi.API.UseCases.Client;
using Microsoft.AspNetCore.Mvc;

namespace AutologApi.API.Endpoints.Client
{
    public static class ClientEndpoints
    {
        public static WebApplication MapClientEndpoints(this WebApplication app)
        {
            var authGroup = app.MapGroup("client");

            authGroup.MapGet("/", GetClient);

            return app;
        }

        private static Task<IResult> GetClient([AsParameters] GetClientUseCaseInput input, [FromServices] GetClientUseCase getClientUseCase)
        {
            return getClientUseCase.Execute(input);
        }
    }
}