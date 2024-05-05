using Microsoft.AspNetCore.Mvc;

namespace AutologApi.API.UseCases
{
    public interface IUseCase<TUseCaseInput>
    {
        Task<IResult> Execute(TUseCaseInput input);
    }
}