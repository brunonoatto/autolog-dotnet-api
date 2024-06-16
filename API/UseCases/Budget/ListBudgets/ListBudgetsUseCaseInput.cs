using System.Security.Claims;
using AutologApi.API.Domain.Models.Configs;
using Microsoft.AspNetCore.Mvc;

namespace AutologApi.API.UseCases
{
    public record ListBudgetsUseCaseInput(
        [FromQuery] string? License,
        PaginationQueryParameters Pagination,
        ClaimsPrincipal User
    );
}
