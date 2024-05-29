using Newtonsoft.Json;
using WeatherMonitoringAndReportingService.WeatherMonitoringAndReportingService.Models;

namespace WeatherMonitoringAndReportingService.WeatherMonitoringAndReportingService.Models.Bots
{

    public class RainBot : BotConfiguration
    {
        [JsonProperty("humidity_threshold")]
        public double Threshold { get; set; }
        public string Message { get; }
        public bool Enabled { get; }
    }
}
