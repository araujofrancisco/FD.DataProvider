using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FD.SampleData.Models.Weather
{
    public class Location
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public bool Favorite { get; set; }
        [ForeignKey("WeatherForecast")]
        public int? WeatherForecastId { get; set; }
        public WeatherForecast WeatherForecast { get; set; }
    }
}
