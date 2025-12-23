using AutologApi.API.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace AutologApi.API.Endpoints
{
    public static class AuthEndpoints
    {
        public static void MapAuthEndpoints(this IEndpointRouteBuilder app)
        {
            var authGroup = app.MapGroup("auth");

            authGroup.MapPost("/login", Login);
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
