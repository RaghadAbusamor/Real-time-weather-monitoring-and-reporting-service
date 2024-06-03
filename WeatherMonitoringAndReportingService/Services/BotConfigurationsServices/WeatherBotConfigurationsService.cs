using Newtonsoft.Json;
using WeatherMonitoringAndReportingService.WeatherMonitoringAndReportingService.Models;

namespace WeatherMonitoringAndReportingService.Services.BotConfigurationsServices
{


    namespace WeatherMonitoringAndReportingService.WeatherMonitoringAndReportingService.Services.BotConfigurationsServices
    {
        public class WeatherBotConfigurationsService

        {
            public static WeatherBotConfigurations Load(string filePath)
            {
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException("Configuration file not found.", filePath);
                }

                string jsonContent = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<WeatherBotConfigurations>(jsonContent);
            }
        }
    }
}