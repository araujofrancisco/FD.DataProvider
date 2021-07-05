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
        public DbSet<ForecastReportType> ForecastReportTypes { get; set; }

        public WeatherForecastDbContext()
        {
        }

        public WeatherForecastDbContext(DbContextOptions<WeatherForecastDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // set model relations
            modelBuilder.Entity<ForecastReportType>()
                .HasKey(wr => new { wr.WeatherForecastId, wr.ReportTypeId });

            modelBuilder.Entity<ForecastReportType>()
               .HasOne(wr => wr.WeatherForecast)
               .WithMany(w => w.ForecastReportTypes)
               .HasForeignKey(wr => wr.WeatherForecastId);

            modelBuilder.Entity<ForecastReportType>()
                .HasOne(wr => wr.ReportType)
                .WithMany(r => r.ForecastReportTypes)
                .HasForeignKey(wr => wr.ReportTypeId);
        }

        /// <summary>
        /// Seed forecasts and report types.
        /// </summary>
        /// <param name="seedSize"></param>
        /// <returns></returns>
        public override async Task Seed(int? seedSize)
        {
            List<ReportType> reportTypes = await WeatherForecastGenerator.GenerateReportTypes();
            await AddRangeAsync(reportTypes);
            await SaveChangesAsync();

            // generates weather forecasts 
            List<WeatherForecast> forecasts = await WeatherForecastGenerator.GenerateForecasts(DateTime.Today, seedSize);
            await AddRangeAsync(forecasts);
            await SaveChangesAsync();

            List<ForecastReportType> forecastReportTypes = await WeatherForecastGenerator.GenerateForecastReportTypes(forecasts, reportTypes);
            await AddRangeAsync(forecastReportTypes);
            await SaveChangesAsync();
        }
    }
}
