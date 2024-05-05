using BC = BCrypt.Net.BCrypt;
using Microsoft.EntityFrameworkCore;
using AutologApi.API.Domain.Model;

namespace AutologApi.API.UseCases.Auth
{
    public class CreateUserClientUseCase(AppDbContext Repository) : IUseCase<CreateUserClientUseCaseInput>
    {
        // Verificar se não vai precisar dele em outro local
        private readonly int SALT = 8;

        public async Task<IResult> Execute(CreateUserClientUseCaseInput input)
        {
            var emailsAlreadyExist = await Repository.Users.FirstOrDefaultAsync(u => u.Email == input.Email || u.Cpf_Cnpj == input.Cpf_Cnpj);

            if (emailsAlreadyExist is not null)
            {
                throw new Exception("Dados informados já cadastrados no sistema.");
            }

            string passwordHashed = BC.HashPassword(input.Password, SALT);
            var newUser = new User
            {
                Name = input.Name,
                Email = input.Email,
                Password = passwordHashed,
                Cpf_Cnpj = input.Cpf_Cnpj,
                Phone = input.Phone,
                Type = UserType.Client
            };

            Repository.Users.Add(newUser);
            await Repository.SaveChangesAsync();

            return Results.Ok(newUser);
        }
    }
}