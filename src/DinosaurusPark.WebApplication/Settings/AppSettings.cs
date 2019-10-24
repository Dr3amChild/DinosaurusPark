using DinosaurusPark.DataAccess;
using DinosaurusPark.Services;

namespace DinosaurusPark.WebApplication.Settings
{
    public class AppSettings
    {
        public DbSettings Db { get; set; }

        public FilesSettings Files { get; set; }

        public SerilogSettings Serilog { get; set; }
    }
}