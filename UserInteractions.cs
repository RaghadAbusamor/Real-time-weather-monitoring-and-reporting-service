using System.Reflection;
using WeatherMonitoringAndReportingService.Attributes;
using WeatherMonitoringAndReportingService.Enums;
using WeatherMonitoringAndReportingService.FileSystem;
using WeatherMonitoringAndReportingService.Models;
using WeatherMonitoringAndReportingService.Models.WeatherDataModels;
using WeatherMonitoringAndReportingService.Services.BotConfigurationsServices;


namespace WeatherMonitoringAndReportingService
{
    public class UserInteractions
    {
        private readonly WeatherBotConfigurationsServices _configurations;

        public UserInteractions(WeatherBotConfigurationsServices configurations)
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
                WeatherData weatherData = await jsonOperations.ParseAsync(filePath);

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
                    WeatherData weatherData = await xmlOperations.ParseAsync(xmlContent); // Pass the XML content to the Parse method
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
            // Get all types in the assembly
            var botTypes = Assembly.GetExecutingAssembly().GetTypes()
                // Filter types that are subclasses of WeatherBotBase
                .Where(t => typeof(BotConfiguration).IsAssignableFrom(t) && !t.IsAbstract)
                // Filter types that have the BotTypeAttribute
                .Where(t => t.GetCustomAttribute<BotTypeAttribute>() != null)
                // Select the types that match the bot type from the configuration
                .Where(t => _configurations.SunBot.BotType.Equals(t.GetCustomAttribute<BotTypeAttribute>().Type));

            foreach (var botType in botTypes)
            {
                // Instantiate the bot dynamically
                var bot = Activator.CreateInstance(botType, _configurations.SunBot) as BotConfiguration;
                // Call the CheckWeather method
                bot?.CheckWeather(weatherData);
            }
        }
    }
}
