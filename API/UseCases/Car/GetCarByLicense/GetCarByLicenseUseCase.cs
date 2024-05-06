using AutologApi.API.Infra.Repository;
using Microsoft.EntityFrameworkCore;

namespace AutologApi.API.UseCases
{
    public class GetCarByLicenseUseCase(AppDbContext Repository)
        : IUseCase<GetCarByLicenseUseCaseInput>
    {
        public async Task<IResult> Execute(GetCarByLicenseUseCaseInput input)
        {
            var car = await Repository.Cars.FirstOrDefaultAsync(c => c.License == input.License);

            if (car is null)
            {
                return Results.NotFound();
            }

            return Results.Ok(car);
        }
    }
}
