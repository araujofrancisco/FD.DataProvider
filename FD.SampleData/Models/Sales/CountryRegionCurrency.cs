using FD.SampleData.Models.Individual;

namespace FD.SampleData.Models.Sales
{
    public partial class CountryRegionCurrency
    {
        public string CountryRegionCode { get; set; }
        public string CurrencyCode { get; set; }
        public System.DateTime ModifiedDate { get; set; }

        public virtual CountryRegion CountryRegion { get; set; }
        public virtual Currency Currency { get; set; }
    }
}
