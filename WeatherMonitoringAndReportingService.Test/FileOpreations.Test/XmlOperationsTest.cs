using WeatherMonitoringAndReportingService.FileSystem;
using WeatherMonitoringAndReportingService.Models.WeatherDataModels;

namespace WeatherMonitoringAndReportingService.Test.FileOperations.Test
{

    public class XMLOperationsTest
    {
        public string filePath = "C:\\Users\\ragha\\OneDrive\\Desktop\\FTS-Internship\\WeatherMonitoringAndReportingService\\WeatherMonitoringAndReportingService\\InputFiles\\XMLFormat.xml";

        [Theory]
        [InlineData("<WeatherData><Location>New York</Location><Temperature>25</Temperature></WeatherData>", "New York", 25)]
        [InlineData("<WeatherData><Location>London</Location><Temperature>20</Temperature></WeatherData>", "London", 20)]
        public async Task Parse_ValidXml_ReturnsDeserializedObject(string xmlContent, string expectedLocation, int expectedTemperature)
        {
            // Arrange
            var xmlOperations = new XMLOperations<WeatherData>();

            // Act
            var result = await xmlOperations.ParseAsync(xmlContent);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<WeatherData>(result);
            Assert.Equal(expectedLocation, result.Location);
            Assert.Equal(expectedTemperature, result.Temperature);
        }

        [Fact]
        public void WriteWeatherData_ValidData_WritesToFile()
        {
            // Arrange
            var xmlOperations = new XMLOperations<WeatherData>();
            var weatherDataList = new List<WeatherData>
            {
                new WeatherData { Location = "New York", Temperature = 25 },
                new WeatherData { Location = "London", Temperature = 20 }
            };

            // Act
            xmlOperations.WriteWeatherData(weatherDataList, filePath);

            // Assert
            Assert.True(File.Exists(filePath));

            //  verify the content written to the file
            string fileContent = File.ReadAllText(filePath);
            Assert.Contains("<Location>New York</Location>", fileContent);
            Assert.Contains("<Temperature>25</Temperature>", fileContent);
            Assert.Contains("<Location>London</Location>", fileContent);
            Assert.Contains("<Temperature>20</Temperature>", fileContent);

        }
    }
}
