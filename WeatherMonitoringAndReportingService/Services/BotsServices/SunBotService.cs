using WeatherMonitoringAndReportingService.Models;
using WeatherMonitoringAndReportingService.Services.BotConfigurationsServices;

namespace WeatherMonitoringAndReportingService.Services.BotsServices
{
    public class SunBotService : CheckWeatherService
    {
        public SunBotService(BotConfiguration configuration) : base(configuration) 
        {
            _configuration = configuration;
        }

    }
}
