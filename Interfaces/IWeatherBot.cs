namespace WeatherMonitoringAndReportingService.Interfaces
{
    public interface IWeatherBot
    {
        string Message { get; }
        bool Enabled { get; }
        double Threshold { get; }
        void CheckWeather(double Threshold);
    }
}
