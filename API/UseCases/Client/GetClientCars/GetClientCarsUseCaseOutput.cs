using AutologApi.API.Domain.Models;

namespace AutologApi.API.UseCases
{
    public record GetClientCarsUseCaseOutput(ICollection<Car> Cars);
}
