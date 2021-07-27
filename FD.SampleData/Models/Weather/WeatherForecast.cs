using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FD.SampleData.Models.Weather
{
    public class WeatherForecast
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int TemperatureC { get; set; }
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
        public string Summary { get; set; }
        public bool Selected { get; set; } = false;
        public int DaylightTime { get; set; }
        public string Phone { get; set; }
        public DateTime? WhenUpdated { get; set; }
        public ICollection<ReportType> ReportTypes { get; set; }
        public List<ForecastReportType> ForecastReportTypes { get; set; }
        public Location Location { get; set; }
    }
}
