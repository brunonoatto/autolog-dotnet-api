namespace Domain.Model;

public enum UserType
{
  Client,
  Garage,
}

public class User : EntityBase
{
  public required string Email { get; set; }
  public required string Password { get; set; }
  public required string Cpf_Cnpj { get; set; }
  public required string Phone { get; set; }
  public required UserType Type { get; set; }

}