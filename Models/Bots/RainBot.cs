using Newtonsoft.Json;
using WeatherMonitoringAndReportingService.Attributes;

namespace WeatherMonitoringAndReportingService.Models.Bots
{
    [BotType("RainBot")]
    public class RainBot : BotConfiguration
    {
        [JsonProperty("humidity_threshold")]
        public double Threshold { get; set; }
        public string Message { get; }
        public bool Enabled { get; }
    }
}
