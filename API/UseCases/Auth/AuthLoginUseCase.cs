using AutologApi.API.Infra.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BC = BCrypt.Net.BCrypt;

namespace AutologApi.API.UseCases
{
    public class AuthLoginUseCase(AppDbContext Repository, TokenService TokenService)
        : IUseCase<AuthLoginUseCaseInput>
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
