using AutologApi.API.Domain.Models.Configs;
using Microsoft.EntityFrameworkCore;

namespace AutologApi.API.Infra.Repository
{
    public static class PaginationFilterRepository
    {
        public static async Task<PaginationResponse<T>> ToListPaginationAsync<T>(
            this IQueryable<T> query,
            PaginationQueryParameters Pagination
        )
        {
            var totalItems = query.Count();
            var totalPages = Math.Round(
                (decimal)totalItems / (decimal)Pagination.PageSize,
                0,
                MidpointRounding.ToPositiveInfinity
            );

            var resultList = await query
                .Skip((Pagination.PageNumber - 1) * Pagination.PageSize)
                .Take(Pagination.PageSize)
                .ToListAsync();

            var response = new PaginationResponse<T>(totalItems, (int)totalPages, resultList);

            return response;
        }
    }
}
