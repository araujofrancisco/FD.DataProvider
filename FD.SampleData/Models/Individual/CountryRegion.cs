using FD.SampleData.Models.Sales;
using System.Collections.Generic;

namespace FD.SampleData.Models.Individual
{
    public partial class CountryRegion
    {
        public CountryRegion()
        {
            this.CountryRegionCurrencies = new HashSet<CountryRegionCurrency>();
            this.SalesTerritories = new HashSet<SalesTerritory>();
            this.StateProvinces = new HashSet<StateProvince>();
        }

        public string CountryRegionCode { get; set; }
        public string Name { get; set; }
        public System.DateTime ModifiedDate { get; set; }

        public virtual ICollection<CountryRegionCurrency> CountryRegionCurrencies { get; set; }
        public virtual ICollection<SalesTerritory> SalesTerritories { get; set; }
        public virtual ICollection<StateProvince> StateProvinces { get; set; }
    }

}
