using AutologApi.API.Endpoints.Client;
using AutologApi.API.Endpoints.User;

namespace AutologApi.API.Endpoints
{
    public static class EndpointExtension
    {
        public static void MapEndpoints(this WebApplication app)
        {
            app
            .MapAuthEndpoints()
            .MapClientEndpoints()
            .MapUserEndpoints();
        }
    }
}