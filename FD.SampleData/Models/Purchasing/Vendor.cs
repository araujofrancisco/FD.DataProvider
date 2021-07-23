using FD.SampleData.Models.Individual;
using System.Collections.Generic;

namespace FD.SampleData.Models.Purchasing
{
    public partial class Vendor
    {
        public Vendor()
        {
            this.ProductVendors = new HashSet<ProductVendor>();
            this.PurchaseOrderHeaders = new HashSet<PurchaseOrderHeader>();
        }

        public int BusinessEntityID { get; set; }
        public string AccountNumber { get; set; }
        public string Name { get; set; }
        public byte CreditRating { get; set; }
        public bool PreferredVendorStatus { get; set; }
        public bool ActiveFlag { get; set; }
        public string PurchasingWebServiceURL { get; set; }
        public System.DateTime ModifiedDate { get; set; }

        public virtual BusinessEntity BusinessEntity { get; set; }
        public virtual ICollection<ProductVendor> ProductVendors { get; set; }
        public virtual ICollection<PurchaseOrderHeader> PurchaseOrderHeaders { get; set; }
    }

}
