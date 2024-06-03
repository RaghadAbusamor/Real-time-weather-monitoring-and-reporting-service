using AutoFixture;
using WeatherMonitoringAndReportingService.WeatherMonitoringAndReportingService.Models;
using WeatherMonitoringAndReportingService.WeatherMonitoringAndReportingService.Services.BotsServices;

namespace WeatherMonitoringAndReportingService.Test.Bots.Test
{
    public class RainBotTest
    {
        private readonly Fixture _fixture;

        public RainBotTest()
        {
            _fixture = new Fixture();
        }

        public static IEnumerable<object[]> EnabledConfigurationsData()
        {
           yield return new object[] { 85, "It's raining", 80 };
           yield return new object[] { 75, "It's raining", 70 };
        }

        public static IEnumerable<object[]> DisabledConfigurationsData()
        {
            yield return new object[] { 85, null, 80 };
            yield return new object[] { 75, null, 80 };
        }

        [Theory]
        [MemberData(nameof(EnabledConfigurationsData))]
        public void CheckWeather_ShouldPrintMessage_WhenConfigurationEnabled(double humidity, string message, int threshold)
        {
            // Arrange
            var configuration = _fixture.Build<BotConfiguration>()
                .With(c => c.Message, message)
                .With(c => c.Threshold, threshold)
                .With(c => c.Enabled, true)
                .Create();
            var rainBotService = new RainBotService(configuration);

            // Act
            rainBotService.CheckWeather(humidity);

            // Assert
            Assert.Equal(message, rainBotService.Message);
        }

        [Theory]
        [MemberData(nameof(DisabledConfigurationsData))]
        public void CheckWeather_ShouldNotPrintMessage_WhenConfigurationDisabled(double humidity, string message, int threshold)
        {
            // Arrange
            var configuration = _fixture.Build<BotConfiguration>()
                .With(c => c.Message, message)
                .With(c => c.Threshold, threshold)
                .With(c => c.Enabled, false)
                .Create();
            var rainBotService = new RainBotService(configuration);

            // Act
            rainBotService.CheckWeather(humidity);

            // Assert
            Assert.Null(rainBotService.Message);
        }
    }
}
