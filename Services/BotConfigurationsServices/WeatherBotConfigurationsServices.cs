using Newtonsoft.Json;

namespace WeatherMonitoringAndReportingService.Services.BotConfigurationsServices
{
    public class WeatherBotConfigurationsServices
    {
        public static WeatherBotConfigurationsServices Load(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Configuration file not found.", filePath);
            }

            string jsonContent = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<WeatherBotConfigurationsServices>(jsonContent);
        }
    }
}
