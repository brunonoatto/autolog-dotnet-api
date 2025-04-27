// using BC = BCrypt.Net.BCrypt;
// using Domain.Model;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.AspNetCore.Authentication.BearerToken;

// namespace Service.Auth
// {
//     public class AuthService : IAuthService
//     {
//         private AppDbContext repository { get; }

//         public AuthService(AppDbContext repository)
//         {
//             this.repository = repository;
//         }

//         public string Login(string email, string password)
//         {


//             var user = repository.Users.FirstOrDefaultAsync(u => u.Email == email);

//             return "jwt";
//         }
//         public async void CreateClient(User user)
//         {
//             var emailsAlreadyExist = await repository.Users.FirstOrDefaultAsync(u => u.Email == user.Email || u.CpfCnpj == user.CpfCnpj);

//             if (emailsAlreadyExist is not null)
//             {
//                 throw new Exception("Dados informados já cadastrados no sistema.");
//             }

//             string passwordHashed = BC.HashPassword(user.Password, Environment.GetEnvironmentVariable("HASH_SALT"));
//             var newUser = new User
//             {

//             }
//             repository.Users.Add(
//                 {
//                 Na
//             }
//             );
//             await repository.SaveChangesAsync();

//             throw new NotImplementedException();
//         }

//         public async void CreateGarage(Garage garage)
//         {
//             CreateClient(garage);

//             var garageAlreadyExist = await repository.Garages.FirstOrDefaultAsync(u => u.Email == garage.Email || u.CpfCnpj == garage.CpfCnpj);

//             if (garageAlreadyExist is not null)
//             {
//                 throw new Exception("Dados informados já cadastrado no sistema.");
//             }

//             repository.Garages.Add(garage);
//             await repository.SaveChangesAsync();

//             throw new NotImplementedException();
//         }

//     }
// }
