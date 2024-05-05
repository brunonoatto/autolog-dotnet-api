
using AutologApi.API.UseCases.UserClient;
using AutologApi.API.UseCases.UserGarage;
using Microsoft.AspNetCore.Mvc;

namespace AutologApi.API.Endpoints.User
{
    public static class UserEndpoints
    {
        public static WebApplication MapUserEndpoints(this WebApplication app)
        {
            var authGroup = app.MapGroup("user");

            authGroup.MapGet("/create-garage", CreateGarage);
            authGroup.MapPost("/create-client", CreateUserClient);

            return app;
        }

        private static Task<IResult> CreateUserClient([FromBody] CreateUserClientUseCaseInput input, [FromServices] CreateUserClientUseCase createUserClientUseCase)
        {
            return createUserClientUseCase.Execute(input);
        }
        private static Task<IResult> CreateGarage([FromBody] CreateUserGarageUseCaseInput input, [FromServices] CreateUserGarageUseCase createUserGarageUseCase)
        {
            return createUserGarageUseCase.Execute(input);
        }
    }
}