using FD.SampleData.Models;
using Microsoft.EntityFrameworkCore;
using System;
//using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace FD.SampleData.Contexts
{
    public class WeatherForecastDbContext : BaseDbContext
    {
        public DbSet<WeatherForecast> WeatherForecasts { get; set; }

        public WeatherForecastDbContext()
        {

        }

        public WeatherForecastDbContext(DbContextOptions<WeatherForecastDbContext> options) : base(options)
        {
#if DEBUG
            Debug.WriteLine($"{ContextId} context created.");
            // we can enable factory logger if is required to check the sql statements
            //MyLoggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });
#endif
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseLoggerFactory(MyLoggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // set model relations

            base.OnModelCreating(modelBuilder);
        }
    }
}
