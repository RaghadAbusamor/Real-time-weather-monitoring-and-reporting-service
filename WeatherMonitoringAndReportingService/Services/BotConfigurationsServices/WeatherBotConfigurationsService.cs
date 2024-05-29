using Newtonsoft.Json;
using WeatherMonitoringAndReportingService.WeatherMonitoringAndReportingService.Models;

namespace WeatherMonitoringAndReportingService.WeatherMonitoringAndReportingService.Services.BotConfigurationsServices
{
    public class WeatherBotConfigurationsServices
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
