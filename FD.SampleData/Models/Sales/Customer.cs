using System;
using System.Collections.Generic;
using FD.SampleData.Models.Individual;

namespace FD.SampleData.Models.Sales
{
    public partial class Customer
    {
        public Customer()
        {
            this.SalesOrderHeaders = new HashSet<SalesOrderHeader>();
        }

        public int CustomerID { get; set; }
        public Nullable<int> PersonID { get; set; }
        public Nullable<int> StoreID { get; set; }
        public Nullable<int> TerritoryID { get; set; }
        public string AccountNumber { get; set; }
        public System.Guid rowguid { get; set; }
        public System.DateTime ModifiedDate { get; set; }

        public virtual Person Person { get; set; }
        public virtual SalesTerritory SalesTerritory { get; set; }
        public virtual Store Store { get; set; }
        public virtual ICollection<SalesOrderHeader> SalesOrderHeaders { get; set; }
    }

}
