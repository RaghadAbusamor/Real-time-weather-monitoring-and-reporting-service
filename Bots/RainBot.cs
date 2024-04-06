
using WeatherMonitoringAndReportingService.Interfaces;
using WeatherMonitoringAndReportingService.WeatherDataModels;
using WeatherMonitoringAndReportingService.BotConfiguration;


namespace WeatherMonitoringAndReportingService.Bots
{
    public class RainBot : IWeatherBot
    {
        private readonly BotConfiguration _config;

        public RainBot(BotConfiguration config)
        {
            _config = config;
        }

        public void CheckWeather(WeatherDataJson data)
        {
            if (_config.Enabled && data.Humidity > _config.Threshold)
            {
                Console.WriteLine("RainBot activated!");
                Console.WriteLine($"RainBot: \"{_config.Message}\"");
            }
        }

        public void CheckWeather(WeatherDataXml data)
        {
            if (_config.Enabled && data.Humidity > _config.Threshold)
            {
                Console.WriteLine("RainBot activated!");
                Console.WriteLine($"RainBot: \"{_config.Message}\"");
            }
        }
    }
}
