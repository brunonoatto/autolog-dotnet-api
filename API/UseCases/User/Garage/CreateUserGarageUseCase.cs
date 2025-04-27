using AutologApi.API.Domain.Models;
using AutologApi.API.Infra.Repository;
using Microsoft.EntityFrameworkCore;
using BC = BCrypt.Net.BCrypt;

namespace AutologApi.API.UseCases
{
    public class CreateUserGarageUseCase(AppDbContext Repository)
        : IUseCase<CreateUserGarageUseCaseInput>
    {
        public async Task<IResult> Execute(CreateUserGarageUseCaseInput input)
        {
            var emailsAlreadyExist = await Repository.Users.FirstOrDefaultAsync(u =>
                u.Email == input.Email || u.CpfCnpj == input.Cnpj
            );

            if (emailsAlreadyExist is not null)
            {
                return Results.Conflict("Dados informados já cadastrados no sistema.");
            }

            string passwordHashed = BC.HashPassword(
                input.Password,
                Environment.GetEnvironmentVariable("HASH_SALT")
            );
            var newUser = new User
            {
                Name = input.Name,
                Email = input.Email,
                Password = passwordHashed,
                CpfCnpj = input.Cnpj,
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
