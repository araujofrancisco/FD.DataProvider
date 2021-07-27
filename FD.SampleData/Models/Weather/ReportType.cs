using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FD.SampleData.Models.Weather
{
    public class ReportType
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<WeatherForecast> WeatherForecasts { get; set; }
        public virtual List<ForecastReportType> ForecastReportTypes { get; set; }
    }
}
