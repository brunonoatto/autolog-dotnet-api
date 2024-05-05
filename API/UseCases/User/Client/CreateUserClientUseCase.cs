using BC = BCrypt.Net.BCrypt;
using Microsoft.EntityFrameworkCore;
using AutologApi.API.Infra.Repository;
using AutologApi.API.Settings;
using AutologApi.API.Domain.Models;

namespace AutologApi.API.UseCases.UserClient
{
    // public class CreateUserClientUseCase(AppDbContext Repository, AppSettings AppSettings) : IUseCase<CreateUserClientUseCaseInput>
    public class CreateUserClientUseCase(AppDbContext Repository) : IUseCase<CreateUserClientUseCaseInput>
    {
        public async Task<IResult> Execute(CreateUserClientUseCaseInput input)
        {
            var emailsAlreadyExist = await Repository.Users.FirstOrDefaultAsync(u => u.Email == input.Email || u.Cpf_Cnpj == input.Cpf_Cnpj);

            if (emailsAlreadyExist is not null)
            {
                return Results.Conflict("Dados informados já cadastrados no sistema.");
            }

            // string passwordHashed = BC.HashPassword(input.Password, AppSettings.Hash.Salt);
            string passwordHashed = BC.HashPassword(input.Password, 8);
            var newUser = new User
            {
                Name = input.Name,
                Email = input.Email,
                Password = passwordHashed,
                Cpf_Cnpj = input.Cpf_Cnpj,
                Phone = input.Phone,
                Type = UserTypeEnum.Client
            };

            Repository.Users.Add(newUser);
            await Repository.SaveChangesAsync();

            return Results.Ok(newUser);
        }
    }
}