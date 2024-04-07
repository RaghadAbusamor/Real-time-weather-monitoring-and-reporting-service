using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherMonitoringAndReportingService.WeatherDataModels;

namespace WeatherMonitoringAndReportingService.Interfaces
{
    public interface IInputFormat<T>
    {
        Task<T?> Parse(string input);
        void WriteWeatherData(List<T> weatherDataList, string filePath);
    }
}
