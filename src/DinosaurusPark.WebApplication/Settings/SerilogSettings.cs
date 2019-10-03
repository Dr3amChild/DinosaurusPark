using Serilog.Events;

namespace DinosaurusPark.WebApplication.Settings
{
    public class SerilogSettings
    {
        public LogEventLevel Level { get; set; }
        public bool UseRequestLogging { get; set; }
    }
}