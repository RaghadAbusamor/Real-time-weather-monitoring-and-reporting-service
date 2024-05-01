namespace WeatherMonitoringAndReportingService.Interfaces
{
    public interface IInputFormat<T>
    {
        Task<T?> Parse(string input);
        void WriteWeatherData(List<T> weatherDataList, string filePath);
    }
}
