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
            modelBuilder.Entity<WeatherForecast>()
                .HasMany(u => u.ReportTypes)
                .WithMany(r => r.WeatherForecasts)
                .UsingEntity<ForecastReportType>(
                    j => j
                        .HasOne(ur => ur.ReportType)
                        .WithMany(t => t.ForecastReportTypes)
                        .HasForeignKey(ur => ur.ReportTypeId),
                    j => j
                        .HasOne(ur => ur.WeatherForecast)
                        .WithMany(t => t.ForecastReportTypes)
                        .HasForeignKey(ur => ur.WeatherForecastId),
                    j =>
                    {
                        j.HasKey(t => new { t.WeatherForecastId, t.ReportTypeId });
                    });

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
            List<WeatherForecast> forecasts = await WeatherForecastGenerator.GenerateForecasts(DateTime.Today, reportTypes, seedSize);
            await AddRangeAsync(forecasts);
            await SaveChangesAsync();
        }
    }
}
