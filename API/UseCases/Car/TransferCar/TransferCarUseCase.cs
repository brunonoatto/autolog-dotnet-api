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

            // TODO: pegar o clientId do usuário logado pelo token enviado
            // if (car.ClientId != TokenData.ClientId)
            // {
            //     return Results.BadRequest("Veículo não pertence ao Cliente logado.");
            // }

            var clientToTransfer = await Repository.Users.FirstOrDefaultAsync(u => u.Id == input.ClientIdToTrasnfer);

            if (clientToTransfer is null)
            {
                return Results.NotFound("Cliente enviado para transferência não cadastrado.");
            }

            car.ClientId = input.ClientIdToTrasnfer;

            Repository.SaveChanges();

            return Results.Ok(car);
        }
    }
}