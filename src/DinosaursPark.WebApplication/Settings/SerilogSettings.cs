using Serilog.Events;

namespace DinosaursPark.WebApplication.Settings
{
    public class SerilogSettings
    {
        public LogEventLevel Level { get; set; }
        public bool UseRequestLogging { get; set; }
    }
}