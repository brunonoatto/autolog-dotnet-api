using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace AutologApi.API.UseCases
{
    public record TransferCarUseCaseInput(
        [FromRoute] Guid CarId,
        [FromRoute] Guid ClientIdToTrasnfer,
        ClaimsPrincipal User
    );
}
