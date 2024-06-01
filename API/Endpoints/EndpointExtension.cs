using AutologApi.API.Endpoints.Budget;
using AutologApi.API.Endpoints.Car;
using AutologApi.API.Endpoints.Client;
using AutologApi.API.Endpoints.Dashboard;
using AutologApi.API.Endpoints.User;

namespace AutologApi.API.Endpoints
{
    public static class EndpointExtension
    {
        public static void MapEndpoints(this WebApplication app)
        {
            app.MapAuthEndpoints()
                .MapCarEndpoints()
                .MapClientEndpoints()
                .MapDashboardEndpoints()
                .MapUserEndpoints()
                .MapBudgetEndpoints()
                .MapBudgetItemEndpoints();
        }
    }
}
