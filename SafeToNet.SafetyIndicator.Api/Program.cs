using System;
using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using SafeToNet.Commons.Logging;
using Serilog;

namespace SafeToNet.SafetyIndicator.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Log.Logger = LoggingManager.CreateLogger();
                CreateHostBuilder(args).Build().Run();
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IWebHostBuilder CreateHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingConfig, config) =>
                {
                    if (Environment.GetEnvironmentVariable("HOSTING_STATION") == "local")
                    {
                        config.SetBasePath(Directory.GetCurrentDirectory());


                        config.AddYamlFile("appsettings.development.yml", optional: true);
                        config.AddYamlFile("appsettings.secrets.development.yml", optional: true);
                    }
                    else
                    {
                        config.AddYamlFile("/opt/stn/conf/appsettings.yml", optional: true);
                        config.AddYamlFile("/opt/stn/conf/appsettings.secrets.yml", optional: true);
                    }
                }).UseStartup<Startup>()
                .UseSerilog();
        }
    }
}