namespace DinosaurusPark.IntegrationTests
{
    public class Settings
    {
        public ApiSettings Api { get; set; }

        public class ApiSettings
        {
            public string Uri { get; set; }
        }
    }
}
