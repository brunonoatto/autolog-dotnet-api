using AutologApi.API.Infra.Repository;
using Microsoft.EntityFrameworkCore;

namespace AutologApi.API.UseCases
{
    public class GetClientCarsUseCase(AppDbContext Repository) : IUseCase<GetClientCarsUseCaseInput>
    {
        public async Task<IResult> Execute(GetClientCarsUseCaseInput input)
        {
            var user = await Repository
                .Users.Include(u => u.Cars)
                .FirstOrDefaultAsync(u => u.Id == input.ClientId);

            if (user is null)
            {
                return Results.NotFound("Usuário não encontrado.");
            }

            return Results.Ok(user.Cars);
        }
    }
}
