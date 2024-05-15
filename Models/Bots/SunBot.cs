using Newtonsoft.Json;
using WeatherMonitoringAndReportingService.Attributes;

namespace WeatherMonitoringAndReportingService.Models.Bots
{
    [BotType("SunBot")]
    public class SunBot : BotConfiguration
    {
        [JsonProperty("temperature_threshold")]
        public double Threshold { get; set; }
        public string Message { get; }
        public bool Enabled { get; }
    }
}
