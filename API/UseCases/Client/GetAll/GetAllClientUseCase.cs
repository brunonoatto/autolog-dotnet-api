using BC = BCrypt.Net.BCrypt;
using Microsoft.EntityFrameworkCore;
using AutologApi.API.Domain.Model;
using AutologApi.API.Infra.Repository;

namespace AutologApi.API.UseCases.Client
{
    public class GetAllClientUseCase(AppDbContext Repository) : IUseCase
    {
        public async Task<IResult> Execute()
        {
            var clients = await Repository
                .Users
                .Where(u => u.Type == UserType.Client)
                .ToListAsync();

            return Results.Ok(clients);
        }
    }
}