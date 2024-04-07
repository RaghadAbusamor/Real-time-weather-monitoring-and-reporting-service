using System;
using WeatherMonitoringAndReportingService.BotConfigurations;

namespace WeatherMonitoringAndReportingService
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var weatherBotConfigurations = WeatherBotConfigurations.Load("C:\\Users\\ragha\\OneDrive\\Desktop\\FTS-Internship\\WeatherMonitoringAndReportingService\\BotConfigurations\\config.json");
            var userInteractions = new UserInteractions(weatherBotConfigurations);
            await userInteractions.Start();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
