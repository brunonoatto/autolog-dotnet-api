using AutologApi.API.Infra.Repository;
using Microsoft.EntityFrameworkCore;

namespace AutologApi.API.UseCases
{
    public class GetClientUseCase(AppDbContext Repository) : IUseCase<GetClientUseCaseInput>
    {
        public async Task<IResult> Execute(GetClientUseCaseInput input)
        {
            var Users = Repository.Users;

            if (input.WithCars)
            {
                Users.Include(u => u.Cars);
            }

            var client = await Users.FirstOrDefaultAsync(u =>
                u.CpfCnpj == input.CpfCnpj || u.Email == input.Email
            );

            if (client is null)
            {
                return Results.NotFound("Cliente não encontrado");
            }

            return Results.Ok(client);
        }
    }
}
