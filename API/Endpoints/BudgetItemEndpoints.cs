using AutologApi.API.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace AutologApi.API.Endpoints.Budget
{
    public static class BudgetItemEndpoints
    {
        public static void MapBudgetItemEndpoints(this IEndpointRouteBuilder app)
        {
            var BudgetGroup = app.MapGroup("budget-item");

            BudgetGroup.MapPost("/{budgetId}", CreateBudgetItem);
            BudgetGroup.MapDelete("/{budgetItemId}", DeleteBudgetItem);
        }

        private static Task<IResult> CreateBudgetItem(
            [AsParameters] CreateBudgetItemUseCaseInput input,
            [FromServices] CreateBudgetItemUseCase useCase
        )
        {
            return useCase.Execute(input);
        }

        private static Task<IResult> DeleteBudgetItem(
            [AsParameters] DeleteBudgetItemUseCaseInput input,
            [FromServices] DeleteBudgetItemUseCase useCase
        )
        {
            return useCase.Execute(input);
        }
    }
}
