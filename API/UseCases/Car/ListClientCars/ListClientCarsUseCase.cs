using AutologApi.API.Infra.Repository;
using Microsoft.EntityFrameworkCore;

namespace AutologApi.API.UseCases
{
    public class ListClientCarsUseCase(AppDbContext Repository) : IUseCase<ListClientCarsUseCaseInput>
    {
        public async Task<IResult> Execute(ListClientCarsUseCaseInput input)
        {
            List<Guid> carsIdFilter = [];
            if (input.Transfereds)
            {
                // TODO: Aqui no futuro, pegar os carros que foram transferidos da tabela de transferência
                carsIdFilter = await Repository
                    .Budgets
                    .Where(b => b.ClientId == input.ClientId)
                    .Select(b => b.CarId)
                    .ToListAsync();
            }

            var cars = await Repository
                .Cars
                .Where(c => c.ClientId == input.ClientId || carsIdFilter.Contains(c.Id))
                .ToListAsync();

            return Results.Ok(cars);
        }
    }
}