using WeatherMonitoringAndReportingService.WeatherMonitoringAndReportingService.Models;
using WeatherMonitoringAndReportingService.WeatherMonitoringAndReportingService.Services.BotConfigurationsServices;

namespace WeatherMonitoringAndReportingService.WeatherMonitoringAndReportingService.Services.BotsServices
{
    public class SunBotService : CheckWeatherService
    {
        public SunBotService(BotConfiguration configuration) : base(configuration) 
        public SunBotService(BotConfiguration configuration)
        {
            _configuration = configuration;
        }

    }
}
