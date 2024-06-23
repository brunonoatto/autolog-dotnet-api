using Microsoft.EntityFrameworkCore;

namespace AutologApi.API.Domain.Models
{
    public enum UserTypeEnum
    {
        Client = 1,
        Garage = 2,
    }

    public class User : EntityBase
    {
        public static string WITHOUT_LOGIN_TEXT = "*";

        public required string Name { get; set; }

        // TODO: Unique
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string CpfCnpj { get; set; }
        public required string Phone { get; set; }
        public required UserTypeEnum Type { get; set; }

        public virtual ICollection<Car> Cars { get; init; } = [];

        public bool HasLogin
        {
            get { return Email != WITHOUT_LOGIN_TEXT; }
        }
    }
}
