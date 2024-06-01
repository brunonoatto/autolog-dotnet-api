using AutologApi.API.Domain.Models;
using AutologApi.API.Infra.Repository;
using Microsoft.EntityFrameworkCore;

namespace AutologApi.API.UseCases
{
    public class CreateCarUseCase(AppDbContext Repository) : IUseCase<CreateCarUseCaseInput>
    {
        public async Task<IResult> Execute(CreateCarUseCaseInput input)
        {
            var isLicenseExist = await Repository.Cars.AnyAsync(c => c.License == input.License);

            if (isLicenseExist)
            {
                return Results.Conflict("Placa já utilizada em outro veículo.");
            }

            var newCar = new Car
            {
                ClientId = input.ClientId,
                License = input.License,
                Brand = input.Brand,
                Model = input.Model,
                Year = input.Year,
            };

            await Repository.Cars.AddAsync(newCar);
            await Repository.SaveChangesAsync();

            return Results.Ok(newCar);
        }
    }
}
