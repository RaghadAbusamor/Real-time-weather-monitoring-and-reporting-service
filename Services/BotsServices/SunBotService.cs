using WeatherMonitoringAndReportingService.Models;
using WeatherMonitoringAndReportingService.Services.BotConfigurationsServices;

namespace WeatherMonitoringAndReportingService.Services.BotsServices
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
