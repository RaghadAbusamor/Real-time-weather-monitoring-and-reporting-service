namespace WeatherMonitoringAndReportingService.Attributes
{

    [AttributeUsage(AttributeTargets.Class)]
    public class BotTypeAttribute : Attribute
    {
        public string Type { get; }

        public BotTypeAttribute(string type)
        {
            Type = type;
        }
    }

}
