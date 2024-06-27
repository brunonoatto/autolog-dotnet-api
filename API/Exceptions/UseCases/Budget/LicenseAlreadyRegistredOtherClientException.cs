namespace AutologApi.API.Exceptions.UseCases.Budget
{
    public class LicenseAlreadyRegistredOtherClientException : CustomException
    {
        public LicenseAlreadyRegistredOtherClientException()
            : base("Placa já cadastrada para um Carro de outro Cliente.") { }
    }
}
