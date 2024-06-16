namespace AutologApi.API.Domain.Models.Configs
{
    public record PaginationQueryParameters(int PageNumber, int PageSize)
    {
        public static ValueTask<PaginationQueryParameters?> BindAsync(HttpContext context) =>
            ValueTask.FromResult<PaginationQueryParameters?>(
                new(
                    PageNumber: int.TryParse(context.Request.Query["pageNumber"], out var number)
                        ? number
                        : 1,
                    PageSize: int.TryParse(context.Request.Query["pageSize"], out var size)
                        ? size
                        : 10
                )
            );
    }
}
