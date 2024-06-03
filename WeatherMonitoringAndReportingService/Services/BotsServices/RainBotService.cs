using WeatherMonitoringAndReportingService.Services.BotConfigurationsServices;
using WeatherMonitoringAndReportingService.WeatherMonitoringAndReportingService.Models;

namespace WeatherMonitoringAndReportingService.WeatherMonitoringAndReportingService.Services.BotsServices
{
    public class RainBotService : CheckWeatherService
    {
        public RainBotService(BotConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }
    }
}
