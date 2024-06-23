using AutologApi.API.Domain.Models;
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
            BudgetGroup.MapGet("/", ListBudgets);
            BudgetGroup.MapGet("/{osOrId}", GetBudget);
            BudgetGroup.MapPatch("/approve/{budgetId}", ApproveBudget);
            BudgetGroup.MapPatch("/send-for-approve/{budgetId}", SendFormApproveBudget);
            BudgetGroup.MapPatch("/start-service/{budgetId}", StartServiceBudget);
            BudgetGroup.MapPatch("/remake/{budgetId}", RemakeBudget);
            BudgetGroup.MapPatch("/completed/{budgetId}", CompletedBudget);
            BudgetGroup.MapPatch("/finish/{budgetId}", FinishBudget);
            BudgetGroup.MapGet("/link-whats/{budgetId}", GetWhatsAppLinkBudget);
            BudgetGroup.MapPatch("/observation/{budgetId}", ObservationUpdate);

            return app;
        }

        private static Task<IResult> ListBudgets(
            [AsParameters] ListBudgetsUseCaseInput input,
            [FromServices] ListBudgetsUseCase useCase
        )
        {
            return useCase.Execute(input);
        }

        private static Task<IResult> CreateBudget(
            [AsParameters] CreateBudgetUseCaseInput input,
            [FromServices] CreateBudgetUseCase useCase
        )
        {
            return useCase.Execute(input);
        }

        private static Task<IResult> GetBudget(
            [AsParameters] GetBudgetUseCaseInput input,
            [FromServices] GetBudgetUseCase useCase
        )
        {
            return useCase.Execute(input);
        }

        private static Task<IResult> ApproveBudget(
            [AsParameters] UpdateStatusBudgetUseCaseInput input,
            [FromServices] UpdateStatusBudgetUseCase useCase
        )
        {
            useCase.NewStatus = BudgetStatusEnum.ApprovedBudget;
            return useCase.Execute(input);
        }

        private static Task<IResult> SendFormApproveBudget(
            [AsParameters] UpdateStatusBudgetUseCaseInput input,
            [FromServices] UpdateStatusBudgetUseCase useCase
        )
        {
            useCase.NewStatus = BudgetStatusEnum.WaitingBudgetApproval;
            return useCase.Execute(input);
        }

        private static Task<IResult> StartServiceBudget(
            [AsParameters] UpdateStatusBudgetUseCaseInput input,
            [FromServices] UpdateStatusBudgetUseCase useCase
        )
        {
            useCase.NewStatus = BudgetStatusEnum.RunningService;
            return useCase.Execute(input);
        }

        private static Task<IResult> RemakeBudget(
            [AsParameters] UpdateStatusBudgetUseCaseInput input,
            [FromServices] UpdateStatusBudgetUseCase useCase
        )
        {
            useCase.NewStatus = BudgetStatusEnum.MakingBudget;
            return useCase.Execute(input);
        }

        private static Task<IResult> CompletedBudget(
            [AsParameters] UpdateStatusBudgetUseCaseInput input,
            [FromServices] UpdateStatusBudgetUseCase useCase
        )
        {
            useCase.NewStatus = BudgetStatusEnum.CarReady;
            return useCase.Execute(input);
        }

        private static Task<IResult> FinishBudget(
            [AsParameters] UpdateStatusBudgetUseCaseInput input,
            [FromServices] UpdateStatusBudgetUseCase useCase
        )
        {
            useCase.NewStatus = BudgetStatusEnum.Finished;
            return useCase.Execute(input);
        }

        private static Task<IResult> GetWhatsAppLinkBudget(
            [AsParameters] GetWhatsAppLinkBudgetUseCaseInput input,
            [FromServices] GetWhatsAppLinkBudgetUseCase useCase
        )
        {
            return useCase.Execute(input);
        }

        private static Task<IResult> ObservationUpdate(
            [AsParameters] ObservationUpdateUseCaseInput input,
            [FromServices] ObservationUpdateUseCase useCase
        )
        {
            return useCase.Execute(input);
        }
    }
}
