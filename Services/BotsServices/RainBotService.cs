using WeatherMonitoringAndReportingService.Models;
using WeatherMonitoringAndReportingService.Services.BotConfigurationsServices;

namespace WeatherMonitoringAndReportingService.Services.BotsServices
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
