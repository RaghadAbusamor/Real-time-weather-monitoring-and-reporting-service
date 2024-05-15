using WeatherMonitoringAndReportingService.Models;
using WeatherMonitoringAndReportingService.Services.BotConfigurationsServices;

namespace WeatherMonitoringAndReportingService.Services.BotsServices
{
    public class SunBotServices : CheckWeatherService
    {
        private readonly BotConfiguration _configuration;

        public SunBotServices(BotConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Message => _configuration.Message;
        public bool Enabled => _configuration.Enabled;

        public void CheckRainWeather(double threshold)
        {
            try
            {
                // Call the base class CheckWeather method directly
                CheckWeather(threshold);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while checking weather for RainBot: {ex.Message}");
            }
        }
    }
}
