using WeatherMonitoringAndReportingService.WeatherDataModels;

namespace WeatherMonitoringAndReportingService.Interfaces
{
    public interface IWeatherBot
    {
        string Message { get; }
        bool Enabled { get; }
        void CheckWeather(double humidity, double temperature);
    }
}
