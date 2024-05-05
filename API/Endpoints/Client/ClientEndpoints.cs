
using AutologApi.API.UseCases.Client;
using Microsoft.AspNetCore.Mvc;

namespace AutologApi.API.Endpoints.Client
{
    public static class ClientEndpoints
    {
        public static WebApplication MapClientEndpoints(this WebApplication app)
        {
            var authGroup = app.MapGroup("client");

            authGroup.MapGet("/", GetAll);

            return app;
        }

        private static Task<IResult> GetAll([FromServices] GetAllClientUseCase getAllClientUseCase)
        {
            return getAllClientUseCase.Execute();
        }
    }
}