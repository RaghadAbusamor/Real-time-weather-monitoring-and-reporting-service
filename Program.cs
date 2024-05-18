using WeatherMonitoringAndReportingService.Services.BotConfigurationsServices;

namespace WeatherMonitoringAndReportingService
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var weatherBotConfiguration = WeatherBotConfigurationsServices.Load("C:\\Users\\ragha\\OneDrive\\Desktop\\FTS-Internship\\WeatherMonitoringAndReportingService\\Services\\BotConfigurationsServices\\config.json");
            var userInteractions = new UserInteractions(weatherBotConfiguration);
            await userInteractions.Start();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
