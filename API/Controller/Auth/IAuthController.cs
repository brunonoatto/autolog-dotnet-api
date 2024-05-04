namespace Controller.Auth
{
    public interface IAuthController
    {
        public string Login(string email, string password);
    }
}