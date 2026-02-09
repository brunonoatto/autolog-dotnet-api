using AutologApi.API.Domain.Models;
using AutologApi.API.Infra.Repository;
using Microsoft.EntityFrameworkCore;

namespace AutologApi.API.UseCases
{
    public class CreateCarUseCase(AppDbContext Repository) : IUseCase<CreateCarUseCaseInput>
    {
        public async Task<IResult> Execute(CreateCarUseCaseInput input)
        {
            var carInput = input.Car;

            var isLicenseExist = await Repository.Cars.AnyAsync(c => c.License == carInput.License);

            if (isLicenseExist)
            {
                return Results.Conflict("Placa já utilizada em outro veículo.");
            }

            var newCar = new Car
            {
                ClientId = input.User.GetClientId(),
                License = carInput.License,
                Model = carInput.Model,
                Year = carInput.Year,
            };

            await Repository.Cars.AddAsync(newCar);
            await Repository.SaveChangesAsync();

            return Results.Ok(newCar);
        }
    }
}
