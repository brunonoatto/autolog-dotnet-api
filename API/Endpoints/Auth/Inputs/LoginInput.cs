namespace Endpoints.Auth.Inputs
{
    public class LoginInput
    {
        public required string Email { get; init; }
        public required string Password { get; init; }
    }
}