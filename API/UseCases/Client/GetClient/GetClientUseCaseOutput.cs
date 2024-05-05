using AutologApi.API.Domain.Models;

namespace AutologApi.API.UseCases.Client
{
    public record GetClientUseCaseOutput(User User, List<Car>? Cars);
}