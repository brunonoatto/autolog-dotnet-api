namespace AutologApi.API.Domain.Models
{
  public enum UserTypeEnum
  {
    Client = 1,
    Garage = 2,
  }

  public class User : EntityBase
  {
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required string Cpf_Cnpj { get; set; }
    public required string Phone { get; set; }
    public required UserTypeEnum Type { get; set; }
  }
}