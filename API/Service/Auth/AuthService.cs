using BC = BCrypt.Net.BCrypt;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.BearerToken;

namespace Service.Auth
{
    public class AuthService : IAuthService
    {
        private AppDbContext repository { get; }

        public AuthService(AppDbContext repository)
        {
            this.repository = repository;
        }

        public string Login(string email, string password)
        {
            string passwordHashed = BC.HashPassword("my password");

            var user = repository.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == passwordHashed);

            return "jwt";
        }
        public async void CreateClient(User user)
        {
            // fazer as validações do objeto enviado - FluentValidation

            var emailsAlreadyExist = await repository.Users.FirstOrDefaultAsync(u => u.Email == user.Email || u.Cpf_Cnpj == user.Cpf_Cnpj);

            if (emailsAlreadyExist is not null)
            {
                throw new Exception("Dados informados já cadastrados no sistema.");
            }

            repository.Users.Add(user);

            throw new NotImplementedException();
        }

        public async void CreateGarage(Garage garage)
        {
            // fazer as validações do objeto enviado - FluentValidation

            CreateClient(garage);

            var garageAlreadyExist = await repository.Garages.FirstOrDefaultAsync(u => u.Email == garage.Email || u.Cpf_Cnpj == garage.Cpf_Cnpj);

            if (garageAlreadyExist is not null)
            {
                throw new Exception("Dados informados já cadastrado no sistema.");
            }

            repository.Garages.Add(garage);

            throw new NotImplementedException();
        }

    }
}