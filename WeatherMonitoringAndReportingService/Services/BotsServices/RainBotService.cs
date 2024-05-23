using WeatherMonitoringAndReportingService.Models;
using WeatherMonitoringAndReportingService.Services.BotConfigurationsServices;

namespace WeatherMonitoringAndReportingService.Services.BotsServices
{
    public class RainBotService : CheckWeatherService
    {
        public RainBotService(BotConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }
    }
}
