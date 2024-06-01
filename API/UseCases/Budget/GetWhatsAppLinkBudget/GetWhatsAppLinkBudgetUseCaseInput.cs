using Microsoft.AspNetCore.Mvc;

namespace AutologApi.API.UseCases
{
    public record GetWhatsAppLinkBudgetUseCaseInput([FromRoute] Guid BudgetId);
}
