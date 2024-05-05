namespace AutologApi.API.Settings
{
    public class ConnectionStrings(string defaultConnection)
    {
        public readonly string DefaultConnection = defaultConnection;
    }
    public class Hash(int salt, string jwtKey)
    {
        public readonly int Salt = salt;
        public readonly string JwtKey = jwtKey;
    };

    public class AppSettings
    {
        public required ConnectionStrings ConnectionStrings { get; set; }
        public required Hash Hash { get; set; }
    }
}