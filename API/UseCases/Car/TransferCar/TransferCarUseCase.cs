using AutologApi.API.Infra.Repository;
using Microsoft.EntityFrameworkCore;

namespace AutologApi.API.UseCases
{
    public class TransferCarUseCase(AppDbContext Repository) : IUseCase<TransferCarUseCaseInput>
    {
        public async Task<IResult> Execute(TransferCarUseCaseInput input)
        {
            var car = await Repository.Cars.FirstOrDefaultAsync(c => c.Id == input.CarId);

            if (car is null)
            {
                return Results.NotFound("Veículo não encontrado.");
            }

            if (car.ClientId != input.User.GetClientId())
            {
                return Results.BadRequest("Veículo não pertence ao Cliente logado.");
            }

            if (car.ClientId == input.ClientIdToTrasnfer)
            {
                return Results.BadRequest("Veículo já pertence a você.");
            }

            var clientToTransfer = await Repository.Users.FirstOrDefaultAsync(u =>
                u.Id == input.ClientIdToTrasnfer
            );

            if (clientToTransfer is null)
            {
                return Results.NotFound("Cliente enviado para transferência não cadastrado.");
            }

            car.ClientId = input.ClientIdToTrasnfer;

            await Repository.SaveChangesAsync();

            return Results.Ok(car);
        }
    }
}
