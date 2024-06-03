using WeatherMonitoringAndReportingService.Services.BotConfigurationsServices;
using WeatherMonitoringAndReportingService.WeatherMonitoringAndReportingService.Models;

namespace WeatherMonitoringAndReportingService.WeatherMonitoringAndReportingService.Services.BotsServices
{
    public class SnowBotService : CheckWeatherService
    {
        public SnowBotService(BotConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }
        public override void CheckWeather(double Threshold)
        {
            try
            {
                if (_configuration != null && _configuration.Enabled && Threshold <= _configuration.Threshold)
                {
                    Message  = _configuration.Message;
                    Console.WriteLine(Message);

                }
            }
            catch (Exception ex)
            {
                Message = null;

                Console.WriteLine($"An error occurred while checking weather for SnowBot: {ex.Message}");
            }
        }
    }
}
