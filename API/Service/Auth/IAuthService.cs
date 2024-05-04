
using Domain.Model;

namespace Service.Auth
{
    public interface IAuthService
    {
        public string Login(string email, string password);
        public void CreateGarage(Garage garage);
        public void CreateClient(User user);
    }
}