using System;
using System.Collections.Generic;

namespace FD.SampleData.Models.Weather
{
    public class WeatherForecast
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int TemperatureC { get; set; }
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
        public string Summary { get; set; }
        public bool Selected { get; set; } = false;
        public int DaylightTime { get; set; }
        public string Phone { get; set; }
        public DateTime? WhenUpdated { get; set; }
        public virtual ICollection<ReportType> ReportTypes { get; set; }
        public virtual List<ForecastReportType> ForecastReportTypes { get; set; }
        public int LocationID { get; set; }
        public virtual Location Location { get; set; }
    }
}
