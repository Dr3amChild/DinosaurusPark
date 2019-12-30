using DinosaursPark.DataAccess;
using DinosaursPark.Services;

namespace DinosaursPark.WebApplication.Settings
{
    public class AppSettings
    {
        public DbSettings Db { get; set; }

        public FilesSettings Files { get; set; }

        public SerilogSettings Serilog { get; set; }
    }
}