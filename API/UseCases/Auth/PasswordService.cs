using BC = BCrypt.Net.BCrypt;

namespace AutologApi.API.UseCases.Auth
{
    public class PasswordService
    {
        public string Create(string value)
        {
            return BC.HashPassword(value, GetSalt());
        }

        public bool Verify(string input, string original)
        {
            return BC.Verify(input, original);
        }

        private int GetSalt()
        {
            string? hashSalt = Environment.GetEnvironmentVariable("HASH_SALT");

            if (hashSalt == null)
            {
                throw new Exception("Dados internos não encontrados.");
            }

            return int.Parse(hashSalt);
        }
    }
}
