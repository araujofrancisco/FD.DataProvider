using System.Collections.Generic;

namespace FD.SampleData.Models.Sales
{
    public partial class SalesReason
    {
        public SalesReason()
        {
            this.SalesOrderHeaderSalesReasons = new HashSet<SalesOrderHeaderSalesReason>();
        }

        public int SalesReasonID { get; set; }
        public string Name { get; set; }
        public string ReasonType { get; set; }
        public System.DateTime ModifiedDate { get; set; }

        public virtual ICollection<SalesOrderHeaderSalesReason> SalesOrderHeaderSalesReasons { get; set; }
    }
}
