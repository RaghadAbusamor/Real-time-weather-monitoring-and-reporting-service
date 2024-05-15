using WeatherMonitoringAndReportingService.Models;
using WeatherMonitoringAndReportingService.Services.BotConfigurationsServices;

namespace WeatherMonitoringAndReportingService.Services.BotsServices
{
    public class SnowBotServices : CheckWeatherService
    {
        private readonly BotConfiguration _configuration;

        public SnowBotServices(BotConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Message => _configuration.Message;
        public bool Enabled => _configuration.Enabled;

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
