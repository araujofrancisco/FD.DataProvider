using FD.SampleData.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace FD.SampleData.Data
{
    public class WeatherForecastGenerator
    {
        public static Task<List<WeatherForecast>> GenerateForecast(DateTime startDate, int? SeedSize = 50)
        {
            var rng = new Random();
            return Task.FromResult(Enumerable.Range(1, (int)SeedSize).Select(index => new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Generics.WeatherTypes[rng.Next(Generics.WeatherTypes.Length)],
                DaylightTime = rng.Next(6, 14 * 60 * 60),
                Phone = $"+{rng.Next(1, 9)}{rng.Next(100, 999)}{rng.Next(100, 999)}{rng.Next(1000, 9999)}",
                WhenUpdated = rng.Next(0, 100) < 30 ? null : DateTime.Now,
                ReportTypes = new List<ReportType>() { (ReportType)rng.Next(0, 3) }
            }).ToList());
        }
    }
}
