using AutologApi.API.Domain.Models;
using AutologApi.API.Infra.Repository;
using Microsoft.EntityFrameworkCore;
using BC = BCrypt.Net.BCrypt;

namespace AutologApi.API.UseCases
{
    // public class CreateUserClientUseCase(AppDbContext Repository, AppSettings AppSettings) : IUseCase<CreateUserClientUseCaseInput>
    public class CreateUserClientUseCase(AppDbContext Repository)
        : IUseCase<CreateUserClientUseCaseInput>
    {
        public async Task<IResult> Execute(CreateUserClientUseCaseInput input)
        {
            var user = await Repository.Users.FirstOrDefaultAsync(u =>
                u.Email == input.Email || u.CpfCnpj == input.CpfCnpj
            );

            if (user is not null)
            {
                if (!user.HasLogin)
                {
                    await CreateExistUser(user, input);

                    return Results.Created();
                }

                return Results.Conflict("Dados informados já cadastrados no sistema.");
            }

            var newUser = new User
            {
                Name = input.Name,
                Email = input.Email,
                Password = GetHashPassword(input.Password),
                CpfCnpj = input.CpfCnpj,
                Phone = input.Phone,
                Type = UserTypeEnum.Client
            };

            Repository.Users.Add(newUser);
            await Repository.SaveChangesAsync();

            return Results.Created();
        }

        private async Task CreateExistUser(User user, CreateUserClientUseCaseInput input)
        {
            user.Name = input.Name;
            user.Phone = input.Phone;
            user.Email = input.Email;

            user.Password = GetHashPassword(input.Password);

            Repository.Users.Update(user);
            await Repository.SaveChangesAsync();
        }

        // Colocar essa função em algum helper
        private string GetHashPassword(string password)
        {
            return BC.HashPassword(password, Environment.GetEnvironmentVariable("HASH_SALT"));
        }
    }
}
