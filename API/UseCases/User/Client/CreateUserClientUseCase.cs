using AutologApi.API.Domain.Models;
using AutologApi.API.Infra.Repository;
using AutologApi.API.UseCases.Auth;
using Microsoft.EntityFrameworkCore;

namespace AutologApi.API.UseCases
{
    public class CreateUserClientUseCase(AppDbContext Repository, PasswordService passwordService)
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
                Password = passwordService.Create(input.Password),
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

            user.Password = passwordService.Create(input.Password);

            Repository.Users.Update(user);
            await Repository.SaveChangesAsync();
        }
    }
}
