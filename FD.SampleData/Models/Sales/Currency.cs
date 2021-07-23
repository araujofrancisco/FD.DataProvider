using System.Collections.Generic;

namespace FD.SampleData.Models.Sales
{ 
    public partial class Currency
    {
        public Currency()
        {
            this.CountryRegionCurrencies = new HashSet<CountryRegionCurrency>();
            this.CurrencyRates = new HashSet<CurrencyRate>();
            this.CurrencyRates1 = new HashSet<CurrencyRate>();
        }

        public string CurrencyCode { get; set; }
        public string Name { get; set; }
        public System.DateTime ModifiedDate { get; set; }

        public virtual ICollection<CountryRegionCurrency> CountryRegionCurrencies { get; set; }
        public virtual ICollection<CurrencyRate> CurrencyRates { get; set; }
        public virtual ICollection<CurrencyRate> CurrencyRates1 { get; set; }
    }
}
