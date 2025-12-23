using AutologApi.API.Endpoints.Budget;
using AutologApi.API.Endpoints.Car;
using AutologApi.API.Endpoints.Client;
using AutologApi.API.Endpoints.Dashboard;
using AutologApi.API.Endpoints.User;

namespace AutologApi.API.Endpoints
{
    public static class EndpointExtension
    {
        public static void MapEndpoints(this IEndpointRouteBuilder app)
        {
            // 1. Cria o grupo principal "/api"
            var apiGroup = app.MapGroup("api");

            // 2. Passa esse grupo para os outros métodos
            apiGroup.MapAuthEndpoints();
            apiGroup.MapCarEndpoints();
            apiGroup.MapClientEndpoints();
            apiGroup.MapDashboardEndpoints();
            apiGroup.MapUserEndpoints();
            apiGroup.MapBudgetEndpoints();
            apiGroup.MapBudgetItemEndpoints();
        }
    }
}
