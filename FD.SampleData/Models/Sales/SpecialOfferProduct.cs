using FD.SampleData.Models.Production;
using System.Collections.Generic;

namespace FD.SampleData.Models.Sales
{
    public partial class SpecialOfferProduct
    {
        public SpecialOfferProduct()
        {
            this.SalesOrderDetails = new HashSet<SalesOrderDetail>();
        }

        public int SpecialOfferID { get; set; }
        public int ProductID { get; set; }
        public System.Guid rowguid { get; set; }
        public System.DateTime ModifiedDate { get; set; }

        public virtual Product Product { get; set; }
        public virtual ICollection<SalesOrderDetail> SalesOrderDetails { get; set; }
        public virtual SpecialOffer SpecialOffer { get; set; }
    }
}
