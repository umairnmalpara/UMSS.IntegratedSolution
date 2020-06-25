using System;
using Serilog;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

namespace UMSS.Web.IntegratedWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Getting the current Web Hosting Environment Value
            var enviromentValue = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            // Reading and building the Configurations of App as per the environment value
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{enviromentValue}.json", optional: true, reloadOnChange: true)
            .Build();

            // This is for serilog
            Log.Logger = new LoggerConfiguration()
                            .ReadFrom.Configuration(configuration)
                            //do this for now
                            //TODO:figure out how to add to Serilog config in appsettings.json
                            .WriteTo.Seq("http://localhost:8081")
                            .CreateLogger();
            try
            {
                Log.Information("Integrated Web Api Starting Up.");
                CreateHostBuilder(args, enviromentValue).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Integrated Web Api failed to start.");
                throw;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args, string enviromentValue) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseEnvironment(enviromentValue);
                });

    }
}
