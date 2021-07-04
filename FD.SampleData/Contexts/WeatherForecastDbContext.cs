using FD.SampleData.Data.Generators;
using FD.SampleData.Models.Weather;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FD.SampleData.Contexts
{
    public class WeatherForecastDbContext : BaseDbContext
    {
        public DbSet<ReportType> ReportTypes { get; set; }
        public DbSet<WeatherForecast> WeatherForecasts { get; set; }

        public WeatherForecastDbContext()
        {
        }

        public WeatherForecastDbContext(DbContextOptions<WeatherForecastDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// Seed roles and users using UserGenerator.
        /// </summary>
        /// <param name="seedSize"></param>
        /// <returns></returns>
        public override async Task Seed(int? seedSize)
        {
            List<ReportType> reportTypes = await WeatherForecastGenerator.GenerateReportTypes();

            // generates weather forecasts 
            List<WeatherForecast> forecasts = await WeatherForecastGenerator.GenerateForecasts(DateTime.Today, reportTypes, seedSize);
            await AddRangeAsync(forecasts);
            await SaveChangesAsync();
        }
    }
}
