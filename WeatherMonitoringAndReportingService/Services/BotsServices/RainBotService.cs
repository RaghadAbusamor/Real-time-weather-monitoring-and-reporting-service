using WeatherMonitoringAndReportingService.WeatherMonitoringAndReportingService.Models;
using WeatherMonitoringAndReportingService.WeatherMonitoringAndReportingService.Services.BotConfigurationsServices;

namespace WeatherMonitoringAndReportingService.WeatherMonitoringAndReportingService.Services.BotsServices
{
    public class RainBotService : CheckWeatherService
    {
        private readonly BotConfiguration _configuration;

        public RainBotService(BotConfiguration configuration)
        {
            _configuration = configuration;
        }
    }
}
