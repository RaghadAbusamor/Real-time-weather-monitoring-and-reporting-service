using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMonitoringAndReportingService.BotConfiguration
{
    public class WeatherBotConfigurations
    {
        public BotConfiguration RainBot { get; set; }
        public BotConfiguration SunBot { get; set; }
        public BotConfiguration SnowBot { get; set; }

        public static WeatherBotConfigurations Load(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Configuration file not found.", filePath);
            }

            string jsonContent = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<WeatherBotConfigurations>(jsonContent);
        }
    }

}
