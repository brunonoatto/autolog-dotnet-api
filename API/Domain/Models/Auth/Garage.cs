namespace AutologApi.API.Domain.Models
{
  public class Garage : EntityBase
  {
    public required Guid UserId { get; set; }
    public required string Address { get; set; }
    public required int AddressNumber { get; set; }
    public string? Complement { get; set; }
    public required User User { get; set; }
  }
}