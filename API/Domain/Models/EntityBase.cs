using System.ComponentModel.DataAnnotations;

namespace AutologApi.API.Domain.Models
{
  public class EntityBase()
  {

    [Key]
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime? UpdatedDate { get; set; }
    public bool IsEnabled { get; set; } = true;
  }
}