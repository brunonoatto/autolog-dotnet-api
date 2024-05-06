using AutologApi.API.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace AutologApi.API.Endpoints
{
    public static class AuthEndpoints
    {
        public static WebApplication MapAuthEndpoints(this WebApplication app)
        {
            var authGroup = app.MapGroup("auth");

            authGroup.MapPost("/login", Login);

            return app;
        }

        private static Task<IResult> Login(
            [FromBody] AuthLoginUseCaseInput input,
            [FromServices] AuthLoginUseCase loginUseCase
        )
        {
            return loginUseCase.Execute(input);
        }
    }
}
