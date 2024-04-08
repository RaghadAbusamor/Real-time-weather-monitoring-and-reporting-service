using System;
using WeatherMonitoringAndReportingService.BotConfigurations;

namespace WeatherMonitoringAndReportingService
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var weatherBotConfiguration = WeatherBotConfigurations.Load("C:\\Users\\ragha\\OneDrive\\Desktop\\FTS-Internship\\WeatherMonitoringAndReportingService\\BotConfigurations\\config.json");
            var userInteractions = new UserInteractions(weatherBotConfiguration);
            await userInteractions.Start();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
