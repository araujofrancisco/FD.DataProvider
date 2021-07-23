using System.Collections.Generic;

namespace FD.SampleData.Models.Individual
{
    public partial class ContactType
    {
        public ContactType()
        {
            this.BusinessEntityContacts = new HashSet<BusinessEntityContact>();
        }

        public int ContactTypeID { get; set; }
        public string Name { get; set; }
        public System.DateTime ModifiedDate { get; set; }

        public virtual ICollection<BusinessEntityContact> BusinessEntityContacts { get; set; }
    }
}
