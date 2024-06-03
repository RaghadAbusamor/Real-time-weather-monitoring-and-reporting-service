using WeatherMonitoringAndReportingService.WeatherMonitoringAndReportingService.FileSystem;
using WeatherMonitoringAndReportingService.WeatherMonitoringAndReportingService.Models.WeatherDataModels;

namespace WeatherMonitoringAndReportingService
{
    public class JsonOperationsTest
    {
        string filePath = "C:\\Users\\ragha\\OneDrive\\Desktop\\FTS-Internship\\WeatherMonitoringAndReportingService\\WeatherMonitoringAndReportingService\\InputFiles\\JSONFormat.json";

        [Fact]
        public async Task Parse_ExistingFile_ReturnsDeserializedObject()
        {
            // Arrange
            var jsonOperations = new JSONOperations<WeatherData>();
            var expectedData = new WeatherData();

            // Act
            var result = await jsonOperations.ParseAsync(filePath);

            // Assert
            Assert.NotNull(result);
            
        }

        [Fact]
        public async Task Parse_NonExistentFile_ThrowsFileNotFoundException()
        {
            // Arrange
            var jsonOperations = new JSONOperations<WeatherData>();
            string nonExistingFilePath = "nonExistingFile.json";

            // Act & Assert
            var exception = await Assert.ThrowsAsync<FileNotFoundException>(() => jsonOperations.ParseAsync(nonExistingFilePath));

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<FileNotFoundException>(exception);
        }



        [Fact]
        public void WriteWeatherData_ValidData_WritesToFile()
        {
            // Arrange
            var jsonOperations = new JSONOperations<WeatherData>();
            var weatherDataList = new List<WeatherData>();

            // Act
            jsonOperations.WriteWeatherData(weatherDataList, filePath);

            // Assert
            Assert.True(File.Exists(filePath));
        }
    }
}
