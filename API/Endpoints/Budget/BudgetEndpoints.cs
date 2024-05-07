using AutologApi.API.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace AutologApi.API.Endpoints.Budget
{
    public static class BudgetEndpoints
    {
        public static WebApplication MapBudgetEndpoints(this WebApplication app)
        {
            var BudgetGroup = app.MapGroup("budget");

            BudgetGroup.MapPost("/", CreateBudget);

            return app;
        }

        private static Task<IResult> CreateBudget(
            [FromBody] CreateBudgetUseCaseInput input,
            [FromServices] CreateBudgetUseCase CreateBudgetUseCase
        )
        {
            return CreateBudgetUseCase.Execute(input);
        }
    }
}
