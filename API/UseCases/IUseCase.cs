namespace AutologApi.API.UseCases
{
    public interface IUseCase<TUseCaseInput>
    {
        Task<IResult> Execute(TUseCaseInput input);
    }

    public interface IUseCase
    {
        Task<IResult> Execute();
    }
}
