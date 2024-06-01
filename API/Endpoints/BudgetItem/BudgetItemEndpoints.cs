using AutologApi.API.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace AutologApi.API.Endpoints.Budget
{
    public static class BudgetItemEndpoints
    {
        public static WebApplication MapBudgetItemEndpoints(this WebApplication app)
        {
            var BudgetGroup = app.MapGroup("budget-item");

            BudgetGroup.MapPost("/{budgetId}", CreateBudgetItem);
            BudgetGroup.MapDelete("/{budgetItemId}", DeleteBudgetItem);

            return app;
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
