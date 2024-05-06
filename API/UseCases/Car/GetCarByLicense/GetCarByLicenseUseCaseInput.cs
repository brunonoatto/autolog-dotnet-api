using Microsoft.AspNetCore.Mvc;

namespace AutologApi.API.UseCases
{
    public record GetCarByLicenseUseCaseInput([FromRoute] string License);
}
