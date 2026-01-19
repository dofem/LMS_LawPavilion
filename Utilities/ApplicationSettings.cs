namespace LIBRARY_MANAGEMENT_SYSTEM.Utilities
{
    public class ApplicationSettings
    {
        public string ApplicationName { get; set; }
        public string Environment { get; set; }
    }

    public class DatabaseSettings
    {
        public string ConnectionString { get; set; }
    }

    public class JwtSettings
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExpiryInMinutes { get; set; }
    }
}
