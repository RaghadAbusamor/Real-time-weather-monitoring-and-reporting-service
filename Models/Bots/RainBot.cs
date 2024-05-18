using Newtonsoft.Json;

namespace WeatherMonitoringAndReportingService.Models.Bots
{
    
    public class RainBot : BotConfiguration
    {
        [JsonProperty("humidity_threshold")]
        public double Threshold { get; set; }
        public string Message { get; }
        public bool Enabled { get; }
    }
}
