using AutologApi.API.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace AutologApi.API.Endpoints.Dashboard
{
    public static class DashboardEndpoints
    {
        public static WebApplication MapDashboardEndpoints(this WebApplication app)
        {
            var DashboardGroup = app.MapGroup("dashboard");

            DashboardGroup.MapGet("garage", GarageDashboard);

            return app;
        }

        private static Task<IResult> GarageDashboard(
            [AsParameters] GarageDashboardUseCaseInput input,
            [FromServices] GarageDashboardUseCase DashboardListItemsUseCase
        )
        {
            return DashboardListItemsUseCase.Execute(input);
        }
    }
}
