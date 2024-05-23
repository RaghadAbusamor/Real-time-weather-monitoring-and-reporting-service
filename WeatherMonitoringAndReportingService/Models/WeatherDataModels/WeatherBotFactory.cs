//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using WeatherMonitoringAndReportingService.Interfaces;
//using WeatherMonitoringAndReportingService.Models.Bots;

//namespace WeatherMonitoringAndReportingService.Models.WeatherDataModels
//{
//    public class WeatherBotFactory : IWeatherBotFactory
//    {
//        public IWeatherBot CreateBot(BotConfiguration botConfiguration, WeatherBotType botType)
//        {
//            return botType switch
//            {
//                WeatherBotType.RainBot => new RainBot(botConfiguration.Message, botConfiguration.HumidityThreshold),
//                WeatherBotType.SunBot => new SunBot(botConfiguration.Message,
//                    (double)botConfiguration.TemperatureThreshold!),
//                WeatherBotType.SnowBot => new SnowBot(botConfiguration.Message,
//                    (double)botConfiguration.TemperatureThreshold!),
//                _ => throw new ArgumentException("Invalid bot type")
//            };
//        }
//    }
