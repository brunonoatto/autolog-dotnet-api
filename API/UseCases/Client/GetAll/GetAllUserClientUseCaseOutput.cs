using AutologApi.API.Domain.Model;

namespace AutologApi.API.UseCases.Client
{
    public record GetAllClientUseCaseOutput(User[] users);
}