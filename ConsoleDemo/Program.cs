using FD.SampleData.Contexts;
using FD.SampleData.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ConsoleDemo
{
    class Program
    {
        public static Task Main(string[] args) =>
            CreateHostBuilder(args).Build().RunAsync();

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            // setup configuration sources
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                config.AddJsonFile("appsettings.json", optional: true);
                config.AddEnvironmentVariables();

                if (args != null)
                    config.AddCommandLine(args);
            })
            // setup services 
            .ConfigureServices((hostContext, services) =>
            {
                services.AddOptions();

                // setup dbcontextfactory and includes a scoped service to indicate the interface
                services.AddDbContextFactory<UserDbContext>(options =>
                {
#if DEBUG
                    options.EnableDetailedErrors(true);
                    options.EnableSensitiveDataLogging(true);
#endif
                });
                services.AddSingleton<FD.SampleData.Interfaces.IDbContextFactory<UserDbContext>, DbContextFactory<UserDbContext>>();
                services.AddScoped(p => p.GetRequiredService<FD.SampleData.Interfaces.IDbContextFactory<UserDbContext>>().CreateContext());

                // does the work we are hosting, also includes a scope for the dataservice
                services.AddHostedService<Worker>()
                    .AddScoped<IDataService, DataService>();
            })
            // setup logging configuration
            .ConfigureLogging((hostingContext, logging) =>
            {
                logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                logging.AddConsole();
            })
            .UseConsoleLifetime();
    }
}