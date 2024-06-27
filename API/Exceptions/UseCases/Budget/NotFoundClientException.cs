namespace AutologApi.API.Exceptions.UseCases.Budget
{
    public class NotFoundClientException : CustomException
    {
        public NotFoundClientException()
            : base("Dados do Cliente não enviados.") { }
    }
}
