namespace AutologApi.API.Infra.Repository
{
    public class PaginationResponse<T>(int totalItems, int totalPages, List<T> items)
    {
        public int TotalItems { get; set; } = totalItems;
        public int TotalPages { get; set; } = totalPages;
        public List<T> Items { get; set; } = items;
    }
}
