namespace Domain.Model;

public class EntityBase
{
  public Guid Id { get; set; }
  public DateTime CreatedDate { get; set; }
  public DateTime UpdatedDate { get; set; }
  public DateTime IsEnabled { get; set; }

}