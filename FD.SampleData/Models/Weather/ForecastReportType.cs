using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FD.SampleData.Models.Weather
{
    public class ForecastReportType
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int WeatherForecastId { get; set; }
        public WeatherForecast WeatherForecast { get; set; }

        public int ReportTypeId { get; set; }
        public ReportType ReportType { get; set; }

    }
}
