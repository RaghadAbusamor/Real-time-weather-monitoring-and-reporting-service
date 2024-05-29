using Newtonsoft.Json;
using WeatherMonitoringAndReportingService.Interfaces;

namespace WeatherMonitoringAndReportingService.WeatherMonitoringAndReportingService.Models
{
    public class BotConfiguration : IWeatherBot
    {

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("threshold")]
        public double Threshold { get; set; }

        void IWeatherBot.CheckWeather(double Threshold)
        {
            throw new NotImplementedException();
        }
    }
}
