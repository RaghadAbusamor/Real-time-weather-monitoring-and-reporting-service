<<<<<<< HEAD
﻿using WeatherMonitoringAndReportingService.BotConfigurations;
=======
﻿using WeatherMonitoringAndReportingService.Services.BotConfigurationsServices;
>>>>>>> Dev

namespace WeatherMonitoringAndReportingService
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var weatherBotConfiguration = WeatherBotConfigurationsServices.Load("C:\\Users\\ragha\\OneDrive\\Desktop\\FTS-Internship\\WeatherMonitoringAndReportingService\\BotConfigurations\\config.json");
            var userInteractions = new UserInteractions(weatherBotConfiguration);
            await userInteractions.Start();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
