using WeatherMonitoringAndReportingService.Services.BotConfigurationsServices;

namespace WeatherMonitoringAndReportingService.Services.BotsServices
{
    public class RainBotService : CheckWeatherService
    {
        private readonly RainBot _rainBot;

        public RainBotService(RainBot rainBot)
        {
            _rainBot = rainBot ?? throw new ArgumentNullException(nameof(rainBot));
        }

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
