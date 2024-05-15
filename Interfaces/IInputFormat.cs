namespace WeatherMonitoringAndReportingService.Interfaces
{
    public interface IInputFormat<T>
    {
        Task<T?> ParseAsync(string input);
        void WriteWeatherData(List<T> weatherDataList, string filePath);
    }
}
