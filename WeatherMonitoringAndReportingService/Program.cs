﻿using WeatherMonitoringAndReportingService.Services.BotConfigurationsServices.WeatherMonitoringAndReportingService.WeatherMonitoringAndReportingService.Services.BotConfigurationsServices;

namespace WeatherMonitoringAndReportingService.WeatherMonitoringAndReportingService
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var weatherBotConfiguration = WeatherBotConfigurationsService.Load("C:\\Users\\ragha\\OneDrive\\Desktop\\FTS-Internship\\WeatherMonitoringAndReportingService\\Services\\BotConfigurationsServices\\config.json");
            var userInteractions = new UserInteractions(weatherBotConfiguration);
            await userInteractions.Start();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
