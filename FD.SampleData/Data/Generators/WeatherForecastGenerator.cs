using FD.SampleData.Models.Weather;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace FD.SampleData.Data.Generators
{
    public class WeatherForecastGenerator
    {
        /// <summary>
        /// Generates a list of random report types.
        /// </summary>
        /// <returns></returns>
        public static Task<List<ReportType>> GenerateReportTypes()
        {
            List<ReportType> reportType = Generics.ReportTypes.Select(r => new ReportType { Name = r }).ToList();
            return Task.FromResult(reportType);
        }

        /// <summary>
        /// Generates a list of forecasts.
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="reportTypes"></param>
        /// <param name="SeedSize"></param>
        /// <returns></returns>
        public static Task<List<WeatherForecast>> GenerateForecasts(DateTime startDate, List<ReportType> reportTypes, int? SeedSize = 50)
        {
            var rng = new Random();
            return Task.FromResult(Enumerable.Range(1, (int)SeedSize).Select(index => new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Generics.WeatherTypes[rng.Next(Generics.WeatherTypes.Length)],
                DaylightTime = rng.Next(6, 14 * 60 * 60),
                Phone = DataGenerator.GeneratePhone(rng),
                WhenUpdated = rng.Next(0, 100) < 30 ? null : DateTime.Now,
                ReportTypes = reportTypes.Where(r => r.Id >= rng.Next(0, reportTypes.Count - 1)).ToList()
            }).ToList());
        }
    }
}
