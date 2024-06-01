using AutologApi.API.Domain.Models;
using AutologApi.API.Infra.Repository;
using Microsoft.EntityFrameworkCore;

namespace AutologApi.API.UseCases
{
    public class GarageDashboardUseCase(AppDbContext Repository)
        : IUseCase<GarageDashboardUseCaseInput>
    {
        public async Task<IResult> Execute(GarageDashboardUseCaseInput input)
        {
            var garageId = input.User.GetGarageId();

            var items = await Repository
                .Budgets.Include(b => b.Car)
                .Include(b => b.User)
                .Where(b =>
                    b.GarageId == garageId && b.IsEnabled && b.Status != BudgetStatusEnum.Finished
                )
                .Select(b => new GarageDashboardUseCaseOutput(
                    b.Os,
                    (int)b.Status,
                    b.Observation,
                    b.Car!.License,
                    b.Car!.Brand,
                    b.Car!.Model,
                    b.Car!.Year,
                    b.User!.Name
                ))
                .ToListAsync();

            return Results.Ok(items);
        }
    }
}
