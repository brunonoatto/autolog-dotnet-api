using AutologApi.API.Domain.Models;
using AutologApi.API.Infra.Repository;
using Microsoft.EntityFrameworkCore;
using BC = BCrypt.Net.BCrypt;

namespace AutologApi.API.UseCases
{
    public class GetClientUseCase(AppDbContext Repository) : IUseCase<GetClientUseCaseInput>
    {
        public async Task<IResult> Execute(GetClientUseCaseInput input)
        {
            var client = await Repository.Users.FirstOrDefaultAsync(u =>
                u.Cpf_Cnpj == input.Cpf_Cnppj || u.Email == input.Email
            );

            if (client is null)
            {
                return Results.NotFound();
            }

            List<Car>? cars = null;
            if (input.WithCars)
            {
                cars = await Repository.Cars.Where(c => c.ClientId == client.Id).ToListAsync();
            }

            var output = new GetClientUseCaseOutput(client, cars);

            return Results.Ok(output);
        }
    }
}
