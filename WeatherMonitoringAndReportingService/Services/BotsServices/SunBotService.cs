using WeatherMonitoringAndReportingService.WeatherMonitoringAndReportingService.Models;
using WeatherMonitoringAndReportingService.WeatherMonitoringAndReportingService.Services.BotConfigurationsServices;

namespace WeatherMonitoringAndReportingService.WeatherMonitoringAndReportingService.Services.BotsServices
{
    public class SunBotService : CheckWeatherService
    {
        private readonly BotConfiguration _configuration;

        public SunBotService(BotConfiguration configuration)
        {
            _configuration = configuration;
        }

    }
}
