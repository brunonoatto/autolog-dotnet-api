
using Service.Auth;

namespace Controller.Auth
{
    public class AuthController : IAuthController
    {
        private IAuthService AuthService { get; }

        public AuthController(IAuthService AuthService)
        {
            this.AuthService = AuthService;
        }

        public string Login(string email, string password)
        {
            return AuthService.Login(email, password);
        }
    }
}