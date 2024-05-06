using AutologApi.API.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace AutologApi.API.Endpoints.Car
{
    public static class CarEndpoints
    {
        public static WebApplication MapCarEndpoints(this WebApplication app)
        {
            var carGroup = app.MapGroup("car");

            carGroup.MapPost("/", CreateCar);
            carGroup.MapGet("/{license}", GetCarByLicense);
            carGroup.MapGet("/client/{clientId}", ListClientCars);
            carGroup.MapPatch("/{carId}/trannfer/{clientIdToTrasnfer}", TransferCar);

            return app;
        }

        private static Task<IResult> CreateCar(
            [FromBody] CreateCarUseCaseInput input,
            [FromServices] CreateCarUseCase CreateCarUseCase
        )
        {
            return CreateCarUseCase.Execute(input);
        }

        private static Task<IResult> GetCarByLicense(
            [AsParameters] GetCarByLicenseUseCaseInput input,
            [FromServices] GetCarByLicenseUseCase GetCarByLicenseUseCase
        )
        {
            return GetCarByLicenseUseCase.Execute(input);
        }

        private static Task<IResult> ListClientCars(
            [AsParameters] ListClientCarsUseCaseInput input,
            [FromServices] ListClientCarsUseCase ListClientCarsUseCase
        )
        {
            return ListClientCarsUseCase.Execute(input);
        }

        private static Task<IResult> TransferCar(
            [AsParameters] TransferCarUseCaseInput input,
            [FromServices] TransferCarUseCase TransferCarUseCase
        )
        {
            return TransferCarUseCase.Execute(input);
        }
    }
}
