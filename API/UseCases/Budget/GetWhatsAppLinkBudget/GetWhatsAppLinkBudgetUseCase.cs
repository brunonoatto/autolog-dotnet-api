using AutologApi.API.Infra.Repository;
using Microsoft.EntityFrameworkCore;

namespace AutologApi.API.UseCases
{
    public class GetWhatsAppLinkBudgetUseCase(AppDbContext Repository)
        : IUseCase<GetWhatsAppLinkBudgetUseCaseInput>
    {
        public async Task<IResult> Execute(GetWhatsAppLinkBudgetUseCaseInput input)
        {
            var budget = await Repository
                .Budgets.Include(b => b.User)
                .Include(b => b.Garage)
                .ThenInclude(g => g!.User)
                .FirstOrDefaultAsync(b => b.Id == input.BudgetId);

            if (budget == null)
            {
                return Results.NotFound("Orçamento não encontrado");
            }

            var whatsAppLink = budget.GetWhatsAppBudgetLink();

            return Results.Ok(new GetWhatsAppLinkBudgetUseCaseOutput(whatsAppLink));
        }
    }
}
