using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherMonitoringAndReportingService.Interfaces;
using WeatherMonitoringAndReportingService.WeatherDataModels;

namespace WeatherMonitoringAndReportingService.Bots
{
    public class SunBot : IWeatherBot
    {
        private readonly BotConfiguration _config;

        public SunBot(BotConfiguration config)
        {
            _config = config;
        }

        public void CheckWeather(WeatherDataJson data)
        {
            if (_config.Enabled && data.Temperature > _config.Threshold)
            {
                Console.WriteLine("SunBot activated!");
                Console.WriteLine($"SunBot: \"{_config.Message}\"");
            }
        }

        public void CheckWeather(WeatherDataXml data)
        {
            if (_config.Enabled && data.Temperature > _config.Threshold)
            {
                Console.WriteLine("SunBot activated!");
                Console.WriteLine($"SunBot: \"{_config.Message}\"");
            }
        }
    }
}
