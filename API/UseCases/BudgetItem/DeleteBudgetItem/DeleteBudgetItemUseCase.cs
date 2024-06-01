using AutologApi.API.Domain.Models;
using AutologApi.API.Infra.Repository;
using Microsoft.EntityFrameworkCore;

namespace AutologApi.API.UseCases
{
    public class DeleteBudgetItemUseCase(AppDbContext Repository)
        : IUseCase<DeleteBudgetItemUseCaseInput>
    {
        public async Task<IResult> Execute(DeleteBudgetItemUseCaseInput input)
        {
            var itemToDeleted = await Repository.BudgetItems.FirstOrDefaultAsync(i =>
                i.Id == input.BudgetItemId
            );

            if (itemToDeleted == null)
            {
                return Results.NotFound("Item do orçamento não encontrado.");
            }

            itemToDeleted.IsEnabled = false;
            // TODO: deletar quando tiver RepositoryBase implementado
            itemToDeleted.UpdatedDate = DateTime.Now;

            Repository.BudgetItems.Update(itemToDeleted);
            await Repository.SaveChangesAsync();

            return Results.Ok();
        }
    }
}
