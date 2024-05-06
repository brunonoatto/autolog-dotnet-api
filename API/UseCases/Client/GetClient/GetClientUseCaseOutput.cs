using AutologApi.API.Domain.Models;

namespace AutologApi.API.UseCases
{
    public record GetClientUseCaseOutput(User User, List<Car>? Cars);
}
