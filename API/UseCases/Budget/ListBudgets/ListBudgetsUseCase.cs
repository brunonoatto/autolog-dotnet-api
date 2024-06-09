using AutologApi.API.Domain.Models;
using AutologApi.API.Infra.Repository;
using Microsoft.EntityFrameworkCore;

namespace AutologApi.API.UseCases
{
    public class ListBudgetsUseCase(AppDbContext Repository) : IUseCase<ListBudgetsUseCaseInput>
    {
        public async Task<IResult> Execute(ListBudgetsUseCaseInput input)
        {
            var userType = input.User.GetUserType();

            var budgetQuery = Repository.Budgets.Include(b => b.Car);

            if (userType == UserTypeEnum.Client)
            {
                budgetQuery.Where(b => b.UserId == input.User.GetClientId());
            }
            else if (userType == UserTypeEnum.Garage)
            {
                budgetQuery.Where(b => b.GarageId == input.User.GetGarageId());
            }
            else
            {
                return Results.BadRequest("Usuário não encontrado.");
            }

            var budgets = await budgetQuery
                .Where(b => b.Car!.License == input.license)
                .Select(b => new ListBudgetsUseCaseOutput(
                    b.Os,
                    b.GarageId,
                    b.Garage!.User!.Name,
                    b.Observation,
                    b.CreatedDate.ToShortDateString(),
                    b.Car!.License,
                    b.Status,
                    b.User!.Name,
                    new CarUseCaseOutput(
                        b.Car.License,
                        b.Car.ClientId,
                        b.Car.Brand,
                        b.Car.Model,
                        b.Car.Year
                    )
                ))
                .ToListAsync();

            return Results.Ok(budgets);
        }
    }
}
