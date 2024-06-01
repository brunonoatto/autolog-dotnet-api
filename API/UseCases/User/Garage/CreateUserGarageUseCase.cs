using AutologApi.API.Domain.Models;
using AutologApi.API.Infra.Repository;
using AutologApi.API.Settings;
using Microsoft.EntityFrameworkCore;
using BC = BCrypt.Net.BCrypt;

namespace AutologApi.API.UseCases
{
    // public class CreateUserGarageUseCase(AppDbContext Repository, AppSettings AppSettings) : IUseCase<CreateUserGarageUseCaseInput>
    public class CreateUserGarageUseCase(AppDbContext Repository)
        : IUseCase<CreateUserGarageUseCaseInput>
    {
        public async Task<IResult> Execute(CreateUserGarageUseCaseInput input)
        {
            var emailsAlreadyExist = await Repository.Users.FirstOrDefaultAsync(u =>
                u.Email == input.Email || u.Cpf_Cnpj == input.Cnpj
            );

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
                Cpf_Cnpj = input.Cnpj,
                Phone = input.Phone,
                Type = UserTypeEnum.Garage
            };

            Repository.Users.Add(newUser);

            var newGarage = new Garage
            {
                UserId = newUser.Id,
                Address = input.Address,
                AddressNumber = input.AddressNumber,
                Complement = input.Complement,
            };
            Repository.Garages.Add(newGarage);

            await Repository.SaveChangesAsync();

            return Results.Ok(newGarage);
        }
    }
}
