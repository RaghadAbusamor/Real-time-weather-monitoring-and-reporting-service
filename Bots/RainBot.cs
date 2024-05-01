﻿using WeatherMonitoringAndReportingService.BotConfigurations;
using WeatherMonitoringAndReportingService.Interfaces;

namespace WeatherMonitoringAndReportingService.Bots
{
    public class RainBot : IWeatherBot
    {
        private readonly BotConfiguration _configuration;

        public RainBot(BotConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Message => _configuration.Message;
        public bool Enabled => _configuration.Enabled;

        public void CheckWeather(double humidity, double temperature)
        {
            try
            {
                if (_configuration != null && _configuration.Enabled && _configuration.HumidityThreshold.HasValue && humidity >= _configuration.HumidityThreshold)
                {
                    Console.WriteLine(_configuration.Message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while checking weather for RainBot: {ex.Message}");
            }
        }
    }
}
