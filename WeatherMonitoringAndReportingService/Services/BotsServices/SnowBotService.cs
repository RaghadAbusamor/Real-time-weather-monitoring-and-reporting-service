using WeatherMonitoringAndReportingService.WeatherMonitoringAndReportingService.Models;
using WeatherMonitoringAndReportingService.WeatherMonitoringAndReportingService.Services.BotConfigurationsServices;

namespace WeatherMonitoringAndReportingService.WeatherMonitoringAndReportingService.Services.BotsServices
{
    public class SnowBotService : CheckWeatherService
    {
        private readonly BotConfiguration _configuration;

        public SnowBotService(BotConfiguration configuration)
        {
            _configuration = configuration;
        }
        public override void CheckWeather(double Threshold)
        {
            try
            {
                if (_configuration != null && _configuration.Enabled && Threshold <= _configuration.Threshold)
                {
                    Console.WriteLine(_configuration.Message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while checking weather for SnowBot: {ex.Message}");
            }
        }
    }
}
