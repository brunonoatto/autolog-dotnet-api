using AutologApi.API.Domain.Models;
using AutologApi.API.Infra.Repository;
using Microsoft.EntityFrameworkCore;

namespace AutologApi.API.UseCases
{
    public class GetClientUseCase(AppDbContext Repository) : IUseCase<GetClientUseCaseInput>
    {
        public async Task<IResult> Execute(GetClientUseCaseInput input)
        {
            User? user;
            if (input.WithCars)
            {
                // TODO: descobrir uma forma melhor sem replicar o filtro
                user = await Repository
                    .Users.Include(u => u.Cars)
                    .FirstOrDefaultAsync(u => u.CpfCnpj == input.CpfCnpj || u.Email == input.Email);
            }
            else
            {
                user = await Repository.Users.FirstOrDefaultAsync(u =>
                    u.CpfCnpj == input.CpfCnpj || u.Email == input.Email
                );
            }

            if (user is null)
            {
                return Results.NotFound("Cliente não encontrado");
            }

            return Results.Ok(user);
        }
    }
}
