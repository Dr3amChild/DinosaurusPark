using DinosaursPark.DataAccess;

namespace DinosaursPark.IntegrationTests
{
    public class Settings
    {
        public ApiSettings Api { get; set; }

        public DbSettings Db { get; set; }

        public class ApiSettings
        {
            public string Uri { get; set; }
        }
    }
}
