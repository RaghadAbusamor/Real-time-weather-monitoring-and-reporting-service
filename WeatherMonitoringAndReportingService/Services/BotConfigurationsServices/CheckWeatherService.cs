using WeatherMonitoringAndReportingService.WeatherMonitoringAndReportingService.Models;

namespace WeatherMonitoringAndReportingService.Services.BotConfigurationsServices
{
    public class CheckWeatherService
    {

        public BotConfiguration _configuration { get; set; }
        public string Message { get;  set; }
        public CheckWeatherService(BotConfiguration configuration)
        {
            _configuration = configuration;
        }

        public virtual void CheckWeather(double threshold)
        {
            try
            {
                if (_configuration.Enabled && threshold >= _configuration.Threshold)
                {
                   Message = _configuration.Message;
                }
            }
            catch (Exception ex)
            {
                Message = null;
                Console.WriteLine($"An error occurred while checking weather: {ex.Message}");
            }
        }
    }
}
