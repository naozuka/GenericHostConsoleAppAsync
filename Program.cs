using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using GenericHostConsoleApp.Interfaces;
using GenericHostConsoleApp.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

// dotnet add package Microsoft.Extensions.Hosting

namespace GenericHostConsoleApp
{
    internal sealed class Program
    {
        private static async Task Main(string[] args)
        {
            await Host.CreateDefaultBuilder(args)
                .UseContentRoot(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                .ConfigureLogging(logging => 
                {
                    // Add any 3rd party loggers like NLog or Serilog
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services
                        .AddHostedService<ConsoleHostedService>()
                        .AddSingleton<IWeatherService, WeatherService>()
                        .AddSingleton<IWeatherService, WeatherService>();

                    services.AddOptions<WeatherSettings>().Bind(hostContext.Configuration.GetSection("Weather"));

                })
                .RunConsoleAsync();
        }
    }
}
