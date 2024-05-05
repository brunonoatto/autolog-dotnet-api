using Microsoft.AspNetCore.Mvc;

namespace AutologApi.API.UseCases
{
    public record GetCarByLicenseUseCaseInput([FromQuery] string License);
}