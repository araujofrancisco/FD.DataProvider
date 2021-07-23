using System.Collections.Generic;

namespace FD.SampleData.Models.Sales
{
    public partial class CreditCard
    {
        public CreditCard()
        {
            this.PersonCreditCards = new HashSet<PersonCreditCard>();
            this.SalesOrderHeaders = new HashSet<SalesOrderHeader>();
        }

        public int CreditCardID { get; set; }
        public string CardType { get; set; }
        public string CardNumber { get; set; }
        public byte ExpMonth { get; set; }
        public short ExpYear { get; set; }
        public System.DateTime ModifiedDate { get; set; }

        public virtual ICollection<PersonCreditCard> PersonCreditCards { get; set; }
        public virtual ICollection<SalesOrderHeader> SalesOrderHeaders { get; set; }
    }
}
