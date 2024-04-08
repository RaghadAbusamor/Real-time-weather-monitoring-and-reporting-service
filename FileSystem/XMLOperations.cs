using System.Xml.Linq;
using System.Xml.Serialization;
using WeatherMonitoringAndReportingService.Interfaces;
using WeatherMonitoringAndReportingService.WeatherDataModels;

namespace WeatherMonitoringAndReportingService.FileSystem
{
    public class XMLOperations<T> : IInputFormat<T>
    {
        public async Task<T?> Parse(string input)
        {
            try
            {
                Console.WriteLine("XML Content before deserialization:");
                Console.WriteLine(input); // Log or print the XML content before deserialization
                return await Task.Run(() =>
                {
                    var serial = new XmlSerializer(typeof(WeatherData));
                    using var reader = new StringReader(input);
                    return (T?)serial.Deserialize(reader);
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while parsing XML: {ex.Message}");
                return default;
            }
        }

        public void WriteWeatherData(List<T> weatherDataList, string filePath)
        {
            try
            {
                var serial = new XmlSerializer(typeof(List<T>));
                using var writer = new StreamWriter(filePath);
                serial.Serialize(writer, weatherDataList);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while writing XML to file: {ex.Message}");
            }
        }
    }

}