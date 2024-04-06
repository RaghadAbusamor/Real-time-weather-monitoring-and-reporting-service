using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherMonitoringAndReportingService.Interfaces;
using WeatherMonitoringAndReportingService.WeatherDataModels;

namespace WeatherMonitoringAndReportingService.Bots
{
    public class SnowBot : IWeatherBot
    {
        private readonly BotConfiguration _config;

        public SnowBot(BotConfiguration config)
        {
            _config = config;
        }

        public void CheckWeather(WeatherDataJson data)
        {
            if (_config.Enabled && data.Temperature < _config.Threshold)
            {
                Console.WriteLine("SnowBot activated!");
                Console.WriteLine($"SnowBot: \"{_config.Message}\"");
            }
        }
        public void CheckWeather(WeatherDataXml data)
        {
            if (_config.Enabled && data.Temperature < _config.Threshold)
            {
                Console.WriteLine("SnowBot activated!");
                Console.WriteLine($"SnowBot: \"{_config.Message}\"");
            }
        }
    }
}
