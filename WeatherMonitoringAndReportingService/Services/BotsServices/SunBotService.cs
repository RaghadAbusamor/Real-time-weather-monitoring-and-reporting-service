using WeatherMonitoringAndReportingService.Services.BotConfigurationsServices;
using WeatherMonitoringAndReportingService.WeatherMonitoringAndReportingService.Models;

namespace WeatherMonitoringAndReportingService.WeatherMonitoringAndReportingService.Services.BotsServices
{
    public class SunBotService : CheckWeatherService
    {
        public SunBotService(BotConfiguration configuration) : base(configuration)
        { 
            _configuration = configuration;
        }

    }
}
