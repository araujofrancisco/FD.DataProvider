using System.Collections.Generic;

namespace FD.SampleData.Models.Weather
{
    public class ReportType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<WeatherForecast> WeatherForecasts { get; set; }
        public virtual List<ForecastReportType> ForecastReportTypes { get; set; }
    }
}
