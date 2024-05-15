using Newtonsoft.Json;
using WeatherMonitoringAndReportingService.Interfaces;

namespace WeatherMonitoringAndReportingService.FileSystem
{
    public class JSONOperations<T> : IInputFormat<T>
    {
<<<<<<< HEAD
        public async Task<T?> Parse2(string filePath)
=======
        public async Task<T?> ParseAsync(string filePath)
>>>>>>> Dev
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException($"File '{filePath}' not found.");
                }

                string json = await File.ReadAllTextAsync(filePath);
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while parsing JSON from file: {ex.Message}");
                return default;
            }
        }
        public async Task<T?> Parse(string filePath)
        {
            try
            {
                string json = await File.ReadAllTextAsync(filePath);
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"File '{filePath}' not found: {ex.Message}");
                throw; // Re-throw the FileNotFoundException
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while parsing JSON from file: {ex.Message}");
                return default;
            }
        }


        public void WriteWeatherData(List<T> weatherDataList, string filePath)
        {
            try
            {
                string json = JsonConvert.SerializeObject(weatherDataList, Formatting.Indented);
                File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while writing JSON to file: {ex.Message}");
            }
        }
    }
}
