using AutologApi.API.Domain.Models;
using AutologApi.API.Infra.Repository;
using AutologApi.API.UseCases.Auth;
using Microsoft.EntityFrameworkCore;

namespace AutologApi.API.UseCases
{
    public class AuthLoginUseCase(
        AppDbContext Repository,
        TokenService TokenService,
        PasswordService passwordService
    ) : IUseCase<AuthLoginUseCaseInput>
    {
        public async Task<IResult> Execute(AuthLoginUseCaseInput input)
        {
            var user = await Repository.Users.FirstOrDefaultAsync(u => u.Email == input.Email);

            if (user is null)
            {
                return Results.Unauthorized();
            }

            var passwordIsValid = passwordService.Verify(input.Password, user.Password);

            if (!passwordIsValid)
            {
                return Results.Unauthorized();
            }

            if (user.Type == UserTypeEnum.Garage)
            {
                var garage = await Repository.Garages.FirstOrDefaultAsync(g => g.UserId == user.Id);

                if (garage is null)
                {
                    return Results.Unauthorized();
                }

                TokenData garageTokenData =
                    new(garage.Id.ToString(), user.Name, UserTypeEnum.Garage);

                var garageAccessToken = TokenService.Generate(garageTokenData);

                return Results.Ok(new UserCreateClientUseCaseOutput(garageAccessToken));
            }

            TokenData clientTokenData = new(user.Id.ToString(), user.Name, UserTypeEnum.Client);

            var clientAccessToken = TokenService.Generate(clientTokenData);

            return Results.Ok(new UserCreateClientUseCaseOutput(clientAccessToken));
        }
    }
}
