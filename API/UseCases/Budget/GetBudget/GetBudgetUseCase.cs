using AutologApi.API.Domain.Models;
using AutologApi.API.Infra.Repository;
using Microsoft.EntityFrameworkCore;

namespace AutologApi.API.UseCases
{
    public class GetBudgetUseCase(AppDbContext Repository) : IUseCase<GetBudgetUseCaseInput>
    {
        public async Task<IResult> Execute(GetBudgetUseCaseInput input)
        {
            Guid? garageId =
                input.User.GetUserType() == UserTypeEnum.Garage ? input.User.GetGarageId() : null;

            var budget = await Repository
                .Budgets.Include(b => b.Items.Where(i => i.IsEnabled))
                .Include(b => b.Car)
                .FirstOrDefaultAsync(b =>
                    b.Os == input.Os && (!garageId.HasValue || b.GarageId == garageId)
                );

            return Results.Ok(budget);
        }
    }
}
