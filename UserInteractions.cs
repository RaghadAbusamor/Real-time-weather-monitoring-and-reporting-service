
using WeatherMonitoringAndReportingService.BotConfigurations;
using WeatherMonitoringAndReportingService.Bots;
using WeatherMonitoringAndReportingService.Enums;
using WeatherMonitoringAndReportingService.FileSystem;
using WeatherMonitoringAndReportingService.WeatherDataModels;

namespace WeatherMonitoringAndReportingService
{
    public class UserInteractions
    {
        private readonly WeatherBotConfigurations _configurations;

        public UserInteractions(WeatherBotConfigurations configurations)
        {
            _configurations = configurations;
        }

        public async Task Start()
        {
            DisplayWelcomeMessage();
            ChooseDataFormat();
        }

        private void DisplayWelcomeMessage()
        {
            Console.WriteLine("Welcome to the Weather Monitoring and Reporting Service!");
        }

        private void ChooseDataFormat()
        {
            Console.WriteLine("Choose data format (JSON/XML):");
            string userInput = Console.ReadLine()?.Trim().ToLower();

            if (Enum.TryParse<DataFormat>(userInput, true, out DataFormat format))
            {
                switch (format)
                {
                    case DataFormat.Json:
                        ReadFromJsonAsync().Wait();
                        break;
                    case DataFormat.Xml:
                        ReadFromXmlAsync().Wait();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid data format. Please choose JSON or XML.");
                ChooseDataFormat();
            }
        }

        private async Task ReadFromJsonAsync()
        {
            Console.WriteLine("Enter file path for JSON data:");
            string filePath = Console.ReadLine()?.Trim();

            if (File.Exists(filePath))
            {
                JSONOperations<WeatherData> jsonOperations = new JSONOperations<WeatherData>();
                WeatherData weatherData = await jsonOperations.Parse(filePath);

                if (weatherData != null)
                {
                    await CheckWeatherForBotsAsync(weatherData);
                }
                else
                {
                    Console.WriteLine("Failed to parse weather data.");
                }
            }
            else
            {
                Console.WriteLine($"File '{filePath}' does not exist.");
                await ReadFromJsonAsync();
            }
        }

        private async Task ReadFromXmlAsync()
        {
            try
            {
                Console.WriteLine("Enter file path for XML data:");
                string filePath = Console.ReadLine()?.Trim();

                if (File.Exists(filePath))
                {
                    string xmlContent = await File.ReadAllTextAsync(filePath); // Read the content of the XML file
                    XMLOperations<WeatherData> xmlOperations = new XMLOperations<WeatherData>();
                    WeatherData weatherData = await xmlOperations.Parse(xmlContent); // Pass the XML content to the Parse method
                }
                else
                {
                    Console.WriteLine($"File '{filePath}' does not exist.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private async Task CheckWeatherForBotsAsync(WeatherData weatherData)
        {
            SunBot sunBot = new SunBot(_configurations.SunBot);
            RainBot rainBot = new RainBot(_configurations.RainBot);
            SnowBot snowBot = new SnowBot(_configurations.SnowBot);

            sunBot.CheckWeather(weatherData.Humidity, weatherData.Temperature);
            rainBot.CheckWeather(weatherData.Humidity, weatherData.Temperature);
            snowBot.CheckWeather(weatherData.Humidity, weatherData.Temperature);
        }
    }
}
