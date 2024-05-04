namespace Domain.Model;

public class Garage : User
{
  public required Guid UserId { get; set; }
  public required string Address { get; set; }
  public required string AddressNumber { get; set; }
  public string? Complement { get; set; }

  // public string Logo { get; set}
}