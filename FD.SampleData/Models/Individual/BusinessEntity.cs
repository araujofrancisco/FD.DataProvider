using FD.SampleData.Models.Purchasing;
using FD.SampleData.Models.Sales;
using System.Collections.Generic;

namespace FD.SampleData.Models.Individual
{
    public partial class BusinessEntity
    {
        public BusinessEntity()
        {
            this.BusinessEntityAddresses = new HashSet<BusinessEntityAddress>();
            this.BusinessEntityContacts = new HashSet<BusinessEntityContact>();
        }

        public int BusinessEntityID { get; set; }
        public System.Guid rowguid { get; set; }
        public System.DateTime ModifiedDate { get; set; }

        public virtual ICollection<BusinessEntityAddress> BusinessEntityAddresses { get; set; }
        public virtual ICollection<BusinessEntityContact> BusinessEntityContacts { get; set; }
        public virtual Person Person { get; set; }
        public virtual Store Store { get; set; }
        public virtual Vendor Vendor { get; set; }
    }
}
