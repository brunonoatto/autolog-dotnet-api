using BC = BCrypt.Net.BCrypt;
using Microsoft.EntityFrameworkCore;
using AutologApi.API.Infra.Repository;
using AutologApi.API.Domain.Models;

namespace AutologApi.API.UseCases.Client
{
    public class GetAllClientUseCase(AppDbContext Repository) : IUseCase
    {
        public async Task<IResult> Execute()
        {
            var clients = await Repository
                .Users
                .Where(u => u.Type == UserTypeEnum.Client)
                .ToListAsync();

            return Results.Ok(clients);
        }
    }
}