namespace MagicVilla_VillaAPI.Extensions
{
    public static class CustomLoggerConfiguration
    {
        public static void AddCustomLogger(this IServiceCollection services)
        {
            /*Log.Logger = new LoggerConfiguration()
                .MinimumLevel
                .Debug()
                .WriteTo
                .File("log/villaLogs.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();*/
        }
    }
}
