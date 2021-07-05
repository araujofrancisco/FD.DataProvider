namespace FD.SampleData.Models.Weather
{
    public class ForecastReportType
    {
        public int WeatherForecastId { get; set; }
        public WeatherForecast WeatherForecast { get; set; }

        public int ReportTypeId { get; set; }
        public ReportType ReportType { get; set; }

    }
}
