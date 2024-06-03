using AutoFixture;
using WeatherMonitoringAndReportingService.WeatherMonitoringAndReportingService.Models;
using WeatherMonitoringAndReportingService.WeatherMonitoringAndReportingService.Services.BotsServices;

namespace WeatherMonitoringAndReportingService.Test.Bots.Test
{
    public class SnowBotTest
    {
        private readonly Fixture _fixture;

        public SnowBotTest()
        {
            _fixture = new Fixture();
        }

        public static IEnumerable<object[]> EnabledConfigurationsData()
        {
            yield return new object[] { "It's snowing", 85, 80 };
            yield return new object[] { "It's snowing", 75, 70};
        }

        public static IEnumerable<object[]> DisabledConfigurationsData()
        {
            yield return new object[] { 50, null, 20 };
            yield return new object[] { 10, null, 20 };
        }

        [Theory]
        [MemberData(nameof(EnabledConfigurationsData))]
        public void CheckWeather_ShouldPrintMessage_WhenTemperatureBelowThreshold(string message, int threshold, double temperature)
        {
            // Arrange
            var configuration = _fixture.Build<BotConfiguration>()
                .With(c => c.Message, message)
                .With(c => c.Threshold, threshold)
                .With(c => c.Enabled, true)
                .Create();
            var snowBotService = new SnowBotService(configuration);

            // Act
            snowBotService.CheckWeather(temperature);

            // Assert
            Assert.Equal(message, snowBotService.Message);
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

        //    Act
            rainBotService.CheckWeather(humidity);

        //    Assert
            Assert.Null(rainBotService.Message);
        }
    }
}
