using AutologApi.API.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace AutologApi.API.Endpoints.Dashboard
{
    public static class DashboardEndpoints
    {
        public static void MapDashboardEndpoints(this IEndpointRouteBuilder app)
        {
            var DashboardGroup = app.MapGroup("dashboard");

            DashboardGroup.MapGet("garage", GarageDashboard);
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
