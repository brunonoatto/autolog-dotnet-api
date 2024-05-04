
using Endpoints.Auth.Inputs;
using Service.Auth;

namespace Controller.Auth
{
    public static class AuthRoutes
    {
        public static void ConfigureAuthRoutes(this WebApplication app)
        {
            var authGroup = app.MapGroup("auth");
            authGroup.MapPost("/login", Login);
            // authGroup.MapGet("/create-garage", CreateGarage);
            // authGroup.MapPost("/create-client", CreateClient);
        }

        private static IResult Login(LoginInput input, IAuthController AuthController)
        {
            try
            {
                return Results.Ok(AuthController.Login(input.Email, input.Password));
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
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
}