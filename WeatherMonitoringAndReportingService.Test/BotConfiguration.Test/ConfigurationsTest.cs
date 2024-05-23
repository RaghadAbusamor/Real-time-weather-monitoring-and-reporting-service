//using WeatherMonitoringAndReportingService.Models.Bots;
//using WeatherMonitoringAndReportingService.Models;
//using WeatherMonitoringAndReportingService.Enums;

//namespace WeatherMonitoringAndReportingService
//{
//    public class ConfigurationsTest
//    {
//        private readonly WeatherBotFactory _factory = new();

//        private readonly BotConfiguration _rainBotConfig = new()
//        {
//            Message = "It's raining",
//            Threshold = 80
//        };

//        private readonly BotConfiguration _snowBotConfig = new()
//        {
//            Message = "It's snowing",
//            Threshold = 0
//        };

//        private readonly BotConfiguration _sunBotConfig = new()
//        {
//            Message = "It's sunny",
//            Threshold = 30
//        };
//        [Fact]
//        public void CreateBot_WithInvalidBotType_ShouldThrowArgumentException()
//        {
//            // Act & Assert
//            Assert.Throws<ArgumentException>(() => _factory.CreateBot(_rainBotConfig, (WeatherBotType)10));
//        }

//        [Fact]
//        public void CreateBot_WithRainBotConfiguration_ShouldReturnRainBot()
//        {
//            // Arrange & Act
//            var bot = _factory.CreateBot(_rainBotConfig, WeatherBotType.RainBot);

//            // Assert
//            Assert.IsType<RainBot>(bot);
//        }

//        [Fact]
//        public void CreateBot_WithSnowBotConfiguration_ShouldReturnSnowBot()
//        {
//            // Arrange & Act
//            var bot = _factory.CreateBot(_snowBotConfig, WeatherBotType.SnowBot);

//            // Assert
//            Assert.IsType<SnowBot>(bot);
//        }

//        [Fact]
//        public void CreateBot_WithSunBotConfiguration_ShouldReturnSunBot()
//        {
//            // Arrange & Act
//            var bot = _factory.CreateBot(_sunBotConfig, WeatherBotType.SunBot);

//            // Assert
//            Assert.IsType<SunBot>(bot);
//        }
//    }
//}
