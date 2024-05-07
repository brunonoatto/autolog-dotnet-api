using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AutologApi.API.Domain.Models
{
    public enum BudgetStatusEnum
    {
        MakingBudget = 1,
        WaitingBudgetApproval = 2,
        ApprovedBudget = 3,
        BudgetRejected = 4,
        RunningService = 5,
        CarReady = 6,
        Finished = 7,
    }

    [PrimaryKey(nameof(Id), nameof(Os))]
    public class Budget : EntityBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Os { get; set; }
        public required Guid GarageId { get; set; }
        public required Guid ClientId { get; set; }
        public required Guid CarId { get; set; }
        public required BudgetStatusEnum Status { get; set; }
        public required string Observation { get; set; }

        public User? Client { get; set; }
        public Garage? Garage { get; set; }
        public Car? Car { get; set; }
    }
}
