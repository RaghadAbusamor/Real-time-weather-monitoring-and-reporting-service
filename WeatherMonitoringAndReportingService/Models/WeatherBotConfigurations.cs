
﻿using WeatherMonitoringAndReportingService.WeatherMonitoringAndReportingService.Models.Bots;

namespace WeatherMonitoringAndReportingService.WeatherMonitoringAndReportingService.Models
{
    public class WeatherBotConfigurations
    {
        public RainBot RainBot { get; set; }
        public SunBot SunBot { get; set; }
        public SnowBot SnowBot { get; set; }
        public WeatherBotConfigurations(BotConfiguration sunBotConfig, BotConfiguration rainBotConfig, BotConfiguration snowBotConfig)
        {
            SunBot = new SunBot();
            RainBot = new RainBot();
            SnowBot = new SnowBot();
        }

    }
}
