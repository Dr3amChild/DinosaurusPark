﻿using DinosaurusPark.DataAccess;

namespace DinosaurusPark.WebApplication.Settings
{
    public class AppSettings
    {
        public DbSettings Db { get; set; }
        public SerilogSettings Serilog { get; set; }
    }
}