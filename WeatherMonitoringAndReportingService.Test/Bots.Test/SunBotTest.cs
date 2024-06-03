using AutoFixture;
using WeatherMonitoringAndReportingService.WeatherMonitoringAndReportingService.Models;
using WeatherMonitoringAndReportingService.WeatherMonitoringAndReportingService.Services.BotsServices;

namespace WeatherMonitoringAndReportingService.Test.Bots.Test
{
    public class SunBotTest
    {
        private readonly Fixture _fixture;

        public SunBotTest()
        {
            _fixture = new Fixture();
        }

        public static IEnumerable<object[]> EnabledConfigurationsData()
        {
            yield return new object[] { 85, "Sun Mode", 80 };
            yield return new object[] { 75, "Sun Mode", 70 };
        }

        public static IEnumerable<object[]> DisabledConfigurationsData()
        {
            yield return new object[] { 85, null, 80 };
            yield return new object[] { 75, null, 80 };
        }

        [Theory]
        [MemberData(nameof(EnabledConfigurationsData))]
        public void CheckWeather_ShouldPrintMessage_WhenTemperatureAboveThreshold( double temperature, string message, int threshold)
        {
            // Arrange
            var configuration = _fixture.Build<BotConfiguration>()
                .With(c => c.Message, message)
                .With(c => c.Threshold, threshold)
                .With(c => c.Enabled, true)
                .Create();
            var sunBotService = new SunBotService(configuration);

            // Act
            sunBotService.CheckWeather(temperature);

            // Assert
            Assert.Equal(message,sunBotService.Message);
        }

        [Theory]
        [MemberData(nameof(DisabledConfigurationsData))]
        public void CheckWeather_ShouldNotPrintMessage_WhenTemperatureBelowThreshold(double temperature, string message, int threshold)
        {
            // Arrange
            var configuration = _fixture.Build<BotConfiguration>()
                .With(c => c.Message, message)
                .With(c => c.Threshold, threshold)
                .With(c => c.Enabled, false)
                .Create();
            var sunBotService = new SunBotService(configuration);

            // Act
            sunBotService.CheckWeather(temperature);

            // Assert

            Assert.Null(sunBotService.Message);


        }

    }
}

