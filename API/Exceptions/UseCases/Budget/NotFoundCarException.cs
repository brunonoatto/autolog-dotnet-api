namespace AutologApi.API.Exceptions.UseCases.Budget
{
    public class NotFoundCarException : CustomException
    {
        public NotFoundCarException()
            : base("Dados do Veículo não enviados.") { }
    }
}
