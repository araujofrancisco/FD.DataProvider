using System.Collections.Generic;

namespace FD.SampleData.Models.Individual
{
    public partial class AddressType
    {
        public AddressType()
        {
            this.BusinessEntityAddresses = new HashSet<BusinessEntityAddress>();
        }

        public int AddressTypeID { get; set; }
        public string Name { get; set; }
        public System.Guid rowguid { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public virtual ICollection<BusinessEntityAddress> BusinessEntityAddresses { get; set; }
    }
}
