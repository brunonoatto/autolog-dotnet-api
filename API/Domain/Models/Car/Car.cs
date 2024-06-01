using Microsoft.EntityFrameworkCore;

namespace AutologApi.API.Domain.Models
{
    [Index(nameof(Id), nameof(License), IsUnique = true)]
    public class Car : EntityBase
    {
        public required Guid ClientId { get; set; }
        public required string License { get; set; }
        public required string Brand { get; set; }
        public required string Model { get; set; }
        public required int Year { get; set; }

        public virtual User? Client { get; init; }
    }
}
