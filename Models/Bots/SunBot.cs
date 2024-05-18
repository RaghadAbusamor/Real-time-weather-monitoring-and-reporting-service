using Newtonsoft.Json;

namespace WeatherMonitoringAndReportingService.Models.Bots
{
    public class SunBot : BotConfiguration
    {
        [JsonProperty("temperature_threshold")]
        public double Threshold { get; set; }
        public string Message { get; }
        public bool Enabled { get; }
    }
}
