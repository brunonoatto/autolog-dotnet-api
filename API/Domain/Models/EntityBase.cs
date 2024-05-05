namespace AutologApi.API.Domain.Model;

public class EntityBase()
{
  public Guid Id { get; set; }
  public DateTime CreatedDate { get; set; } = DateTime.Now;
  public DateTime? UpdatedDate { get; set; }
  public bool IsEnabled { get; set; } = true;
}