using FD.SampleData.Data;
using FD.SampleData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
        }

        /// <summary>
        /// Seed roles and users using UserGenerator.
        /// </summary>
        /// <param name="seedSize"></param>
        /// <returns></returns>
        public override async Task Seed(int? seedSize)
        {
            // generates weather forecasts 
            List<WeatherForecast> forecasts = await WeatherForecastGenerator.GenerateForecast(DateTime.Today, seedSize);
            await AddRangeAsync(forecasts);
            await SaveChangesAsync();
        }
    }
}
