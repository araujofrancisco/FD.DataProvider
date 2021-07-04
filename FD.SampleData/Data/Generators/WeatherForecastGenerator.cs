using FD.SampleData.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace FD.SampleData.Data.Generators
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
                Phone = DataGenerator.GeneratePhone(rng),
                WhenUpdated = rng.Next(0, 100) < 30 ? null : DateTime.Now,
                ReportTypes = new List<ReportType>() { (ReportType)rng.Next(0, 3) }
            }).ToList());
        }
    }
}
