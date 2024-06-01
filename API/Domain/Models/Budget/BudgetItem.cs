using AutologApi.API.Domain.Models.Configs;

namespace AutologApi.API.Domain.Models
{
    public class BudgetItem : EntityBase
    {
        public required Guid BudgetId { get; set; }
        public required string Description { get; set; }
        public required int Qtd { get; set; }

        [DecimalPrecisionCustom]
        public required decimal Price { get; set; }

        public Budget? Budget { get; set; }
    }
}
