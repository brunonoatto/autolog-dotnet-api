using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using System.Web;

namespace AutologApi.API.Domain.Models
{
    public enum BudgetStatusEnum
    {
        None = 0,
        MakingBudget = 1,
        WaitingBudgetApproval = 2,
        ApprovedBudget = 3,
        BudgetRejected = 4,
        RunningService = 5,
        CarReady = 6,
        Finished = 7,
    }

    public class Budget : EntityBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Os { get; set; }
        public required Guid GarageId { get; set; }
        public required Guid UserId { get; set; }
        public required Guid CarId { get; set; }
        public required BudgetStatusEnum Status { get; set; }
        public string? Observation { get; set; }
        public string? ObservationClient { get; set; }

        public virtual User? User { get; set; }
        public virtual Garage? Garage { get; set; }
        public virtual Car? Car { get; set; }
        public virtual ICollection<BudgetItem> Items { get; set; } = [];

        public string GetWhatsAppBudgetLink()
        {
            // TODO: colocar url da aplicação nas envs
            var APP_URL = "https://d1nf456dx65l85.cloudfront.net";
            var budgetLink = User!.HasLogin
                ? $"{APP_URL}/cliente/orcamento/{Os}"
                : $"{APP_URL}/orcamento/{Id}";

            var message =
                $"Olá {User?.Name}, aqui é da mecânica {Garage?.User?.Name}.\n\n"
                + "Seu orçamento está pronto, clique no link abaixo para revisar e aprovar.\n"
                + $"Iniciaremos o serviço mediante aprovação do orçamento.\n\nLink: {budgetLink}";

            string phoneNumber = Regex.Replace(User!.Phone, @"[^\d]", "");

            var whatsAppLink =
                $"https://wa.me/55{phoneNumber}?text={HttpUtility.UrlEncode(message)}";

            return whatsAppLink;
        }
    }
}
