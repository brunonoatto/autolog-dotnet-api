using AutologApi.API.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace AutologApi.API.Endpoints.User
{
    public static class UserEndpoints
    {
        public static void MapUserEndpoints(this IEndpointRouteBuilder app)
        {
            var userGroup = app.MapGroup("user");

            userGroup.MapPost("/create-garage", CreateGarage);
            userGroup.MapPost("/create-client", CreateUserClient);
        }

        private static Task<IResult> CreateUserClient(
            [FromBody] CreateUserClientUseCaseInput input,
            [FromServices] CreateUserClientUseCase createUserClientUseCase
        )
        {
            return createUserClientUseCase.Execute(input);
        }

        private static Task<IResult> CreateGarage(
            [FromBody] CreateUserGarageUseCaseInput input,
            [FromServices] CreateUserGarageUseCase createUserGarageUseCase
        )
        {
            return createUserGarageUseCase.Execute(input);
        }
    }
}
