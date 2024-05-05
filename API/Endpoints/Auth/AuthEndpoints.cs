
using AutologApi.API.UseCases.Auth;
using Microsoft.AspNetCore.Mvc;

namespace AutologApi.API.Endpoints
{
    public static class AuthEndpoints
    {
        public static void MapAuthEndpoints(this WebApplication app)
        {
            var authGroup = app.MapGroup("auth");
            authGroup.MapPost("/login", Login);
            // authGroup.MapGet("/create-garage", CreateGarage);
            authGroup.MapPost("/create-client", CreateUserClient);
        }

        private static Task<IResult> Login([FromBody] AuthLoginUseCaseInput input, [FromServices] AuthLoginUseCase loginUseCase)
        {
            return loginUseCase.Execute(input);
        }

        private static Task<IResult> CreateUserClient([FromBody] CreateUserClientUseCaseInput input, [FromServices] CreateUserClientUseCase loginUseCase)
        {
            return loginUseCase.Execute(input);
        }
    }

    // private static IResult CreateGarage(int id)
    // {
    //     // try
    //     // {
    //     //     var customer = customerService.GetCustomer(id);
    //     //     return customer is null ? Results.NotFound() : Results.Ok(customer);
    //     // }
    //     // catch (Exception ex)
    //     // {
    //     //     return Results.Problem(ex.Message);
    //     // }
    // }

    // private static IResult CreateClient()
    // {
    //     // try
    //     // {
    //     //     customerService.InsertCustomer(customer);
    //     //     return Results.Created($"/customers/{customer.Id}", customer);
    //     // }
    //     // catch (Exception ex)
    //     // {
    //     //     return Results.Problem(ex.Message);
    //     // }
    // }
}