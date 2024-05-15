using WeatherMonitoringAndReportingService.Models;

namespace WeatherMonitoringAndReportingService.Services.BotConfigurationsServices
{
    public class CheckWeatherService
    {
        protected BotConfiguration Configuration { get; }
        public virtual void CheckWeather(double threshold)
        {
            try
            {
                if (Configuration.Enabled && threshold >= Configuration.Threshold)
                {
                    Console.WriteLine(Configuration.Message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while checking weather for SunBot: {ex.Message}");
            }
        }
    }
}
