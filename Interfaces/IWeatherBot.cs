using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherMonitoringAndReportingService.WeatherDataModels;

namespace WeatherMonitoringAndReportingService.Interfaces
{
    public interface IWeatherBot
    {
        void CheckWeather(WeatherDataJson data);
        void CheckWeather(WeatherDataXml data);
    }
}
