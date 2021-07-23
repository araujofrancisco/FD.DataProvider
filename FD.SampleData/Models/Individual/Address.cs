using FD.SampleData.Models.Sales;
using System.Collections.Generic;

namespace FD.SampleData.Models.Individual
{
    public partial class Address
    {
        public Address()
        {
            this.BusinessEntityAddresses = new HashSet<BusinessEntityAddress>();
            this.SalesOrderHeaders = new HashSet<SalesOrderHeader>();
            this.SalesOrderHeaders1 = new HashSet<SalesOrderHeader>();
        }

        public int AddressID { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public int StateProvinceID { get; set; }
        public string PostalCode { get; set; }

        //TODO: this requires NetTopologySuite from NuGet package
        //public System.Data.Entity.Spatial.DbGeography SpatialLocation { get; set; }

        public System.Guid rowguid { get; set; }
        public System.DateTime ModifiedDate { get; set; }

        public virtual StateProvince StateProvince { get; set; }
        public virtual ICollection<BusinessEntityAddress> BusinessEntityAddresses { get; set; }
        public virtual ICollection<SalesOrderHeader> SalesOrderHeaders { get; set; }
        public virtual ICollection<SalesOrderHeader> SalesOrderHeaders1 { get; set; }
    }
}
