using AutologApi.API.Domain.Models;

namespace AutologApi.API.UseCases.Client
{
    public record GetAllClientUseCaseOutput(User[] users);
}