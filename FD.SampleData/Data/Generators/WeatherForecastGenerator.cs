using FD.Blazor.Core;
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
        public static Task<List<Location>> GenerateLocations(int? SeedSize = 50)
        {
            var rng = new Random();
            List<Location> locations = Enumerable.Range(1, (int)SeedSize).Select(index => new Location
            {
                Id = index,
                City = Generics.Cities[rng.Next(Generics.Cities.Length)],
                Favorite = rng.Next(0, 100) == 97,
                Zip = rng.Next(10000, 99999).ToString()
            })
                .DistinctBy(l => l.City+l.Zip)
                .ToList();

            //TODO: if seed size is too big we might find issues with infite cycle
            //      on reasonable seed size there should not be issues
            while (locations.Count < SeedSize)
            {
                // add more locations to match seed size and verify there are not duplicates
                locations.AddRange((IEnumerable<Location>)GenerateLocations(SeedSize - locations.Count));
                locations = locations.DistinctBy(l => l.City + l.Zip).ToList();
            }

            return Task.FromResult(locations);
        }

        /// <summary>
        /// Generates a list of random report types.
        /// </summary>
        /// <returns></returns>
        public static Task<List<ReportType>> GenerateReportTypes()
        {
            //List<ReportType> reportType = Generics.ReportTypes.Select(r => new ReportType { Name = r }).ToList();
            //return Task.FromResult(reportType);
            return Task.FromResult(Enumerable.Range(1, (int)Generics.ReportTypes.Length).Select(index => new ReportType
            {
                Id = index,
                Name = Generics.ReportTypes[index-1]
            }).ToList());
        }

        /// <summary>
        /// Generates a list of forecasts.
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="reportTypes"></param>
        /// <param name="SeedSize"></param>
        /// <returns></returns>
        public static Task<List<WeatherForecast>> GenerateForecasts(DateTime startDate, List<ReportType> reportTypes, List<Location> locations, int? SeedSize = 50)
        {
            var rng = new Random();
            List<WeatherForecast> forecasts = Enumerable.Range(1, (int)SeedSize).Select(index => new WeatherForecast
            {
                Id = index,
                Date = startDate.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Generics.WeatherTypes[rng.Next(Generics.WeatherTypes.Length)],
                DaylightTime = rng.Next(6, 14 * 60 * 60),
                Phone = DataGenerator.GeneratePhone(rng),
                WhenUpdated = rng.Next(0, 100) < 30 ? null : DateTime.Now,
                ReportTypes = reportTypes.Where(r => r.Name.Length * 10 > rng.Next(999) || r.Name.Length * 10 < rng.Next(100)).ToList(),
            }).ToList();

            // assign locations, they all should be unique so we do not get multiple forecasts for same location
            // since we ensure that there are as many locations as indicated by SeedSize we should not have errors
            // by trying to access/remove locations
            forecasts.ForEach(f => { f.Location = locations.First(); locations.RemoveAt(0); });

            return Task.FromResult(forecasts);
        }
    }
}
