using AutologApi.API.Domain.Models;

namespace AutologApi.API.UseCases
{
    public record TokenData(string Id, string Name, UserTypeEnum Type);
}
