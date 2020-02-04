using Serilog.Events;

namespace DinosaursPark.WebApplication.Settings
{
    public class SerilogSettings
    {
        public LogEventLevel SystemLogsLevel { get; set; }
        public LogEventLevel MicrosoftLogsLevel { get; set; }
        public LogEventLevel CustomLogsLevel { get; set; }
        public bool UseRequestLogging { get; set; }
    }
}