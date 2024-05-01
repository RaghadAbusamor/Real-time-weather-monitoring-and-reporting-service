using WeatherMonitoringAndReportingService.BotConfigurations;
using WeatherMonitoringAndReportingService.Interfaces;

namespace WeatherMonitoringAndReportingService.Bots
{
    public class SunBot : IWeatherBot
    {
        private readonly BotConfiguration _configuration;

        public SunBot(BotConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Message => _configuration.Message;
        public bool Enabled => _configuration.Enabled;

        public void CheckWeather(double humidity, double temperature)
        {
            try
            {
                if (_configuration != null && _configuration.Enabled && _configuration.TemperatureThreshold.HasValue && temperature >= _configuration.TemperatureThreshold)
                {
                    Console.WriteLine(_configuration.Message);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while checking weather for SunBot: {ex.Message}");

            }
        }
    }
}
