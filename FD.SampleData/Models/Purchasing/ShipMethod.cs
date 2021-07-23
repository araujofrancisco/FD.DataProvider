using FD.SampleData.Models.Sales;
using System.Collections.Generic;

namespace FD.SampleData.Models.Purchasing
{
    public partial class ShipMethod
    {
        public ShipMethod()
        {
            this.PurchaseOrderHeaders = new HashSet<PurchaseOrderHeader>();
            this.SalesOrderHeaders = new HashSet<SalesOrderHeader>();
        }

        public int ShipMethodID { get; set; }
        public string Name { get; set; }
        public decimal ShipBase { get; set; }
        public decimal ShipRate { get; set; }
        public System.Guid rowguid { get; set; }
        public System.DateTime ModifiedDate { get; set; }

        public virtual ICollection<PurchaseOrderHeader> PurchaseOrderHeaders { get; set; }
        public virtual ICollection<SalesOrderHeader> SalesOrderHeaders { get; set; }
    }

}
