using BC = BCrypt.Net.BCrypt;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace AutologApi.API.UseCases.Auth
{
    public class AuthLoginUseCase(AppDbContext Repository) : IUseCase<AuthLoginUseCaseInput>
    {
        public async Task<IResult> Execute(AuthLoginUseCaseInput input)
        {
            var user = await Repository.Users.FirstOrDefaultAsync(u => u.Email == input.Email);

            if (user is null)
            {
                return Results.Unauthorized();
            }

            var passwordIsValid = BC.Verify(input.Password, user.Password);

            if (!passwordIsValid)
            {
                return Results.Unauthorized();
            }

            var accessToken = TokenService.Generate(user);


            return Results.Ok(new UserCreateClientUseCaseOutput(accessToken));
        }
    }
}