using System.Diagnostics;
using AutologApi.API.Domain.Models;
using AutologApi.API.Infra.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace AutologApi.API.UseCases
{
    public class ListBudgetsUseCase(AppDbContext Repository) : IUseCase<ListBudgetsUseCaseInput>
    {
        public async Task<IResult> Execute(ListBudgetsUseCaseInput input)
        {
            var userType = input.User.GetUserType();

            var budgetQuery = Repository.Budgets.Include(b => b.Car);

            var budgets =
                userType == UserTypeEnum.Client
                    ? budgetQuery.Where(b => b.UserId == input.User.GetClientId())
                    : budgetQuery.Where(b => b.GarageId == input.User.GetGarageId());

            if (!input.License.IsNullOrEmpty())
                budgets = budgets.Where(b => b.Car!.License == input.License);

            var result = await budgets
                .Select(b => new ListBudgetsUseCaseOutput(
                    b.Os,
                    b.GarageId,
                    b.Garage!.User!.Name,
                    b.Observation,
                    b.ObservationClient,
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
                .ToListPaginationAsync(input.Pagination);

            return Results.Ok(result);
        }
    }
}
