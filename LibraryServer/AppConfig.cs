namespace LibraryServer
{
    public static class AppConfig
    {
        public static string SecretKey { get; }

        public const string SecretKeyEnviroment = "SECRET_KEY";
        static AppConfig()
        {
            SecretKey = Environment.GetEnvironmentVariable(SecretKeyEnviroment);
        }
    }
}
