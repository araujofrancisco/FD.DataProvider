using System.Collections.Generic;

namespace FD.SampleData.Models.Individual
{
    public partial class PhoneNumberType
    {
        public PhoneNumberType()
        {
            this.PersonPhones = new HashSet<PersonPhone>();
        }

        public int PhoneNumberTypeID { get; set; }
        public string Name { get; set; }
        public System.DateTime ModifiedDate { get; set; }

        public virtual ICollection<PersonPhone> PersonPhones { get; set; }
    }
}
