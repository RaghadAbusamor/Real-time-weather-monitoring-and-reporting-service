using WeatherMonitoringAndReportingService.Bots;
using WeatherMonitoringAndReportingService.Enums;
using WeatherMonitoringAndReportingService.Interfaces;

namespace WeatherMonitoringAndReportingService.BotConfigurations
{
    public class WeatherBotFactory
    {
        public IWeatherBot CreateBot(BotConfiguration configuration, WeatherBotType botType)
        {
            switch (botType)
            {
                case WeatherBotType.RainBot:
                    return new RainBot(configuration);
                case WeatherBotType.SunBot:
                    return new SunBot(configuration);
                case WeatherBotType.SnowBot:
                    return new SnowBot(configuration);
                default:
                    throw new ArgumentException("Invalid bot type");
            }
        }
    }
}