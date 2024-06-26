﻿using FD.SampleData.Models.Individual;

namespace FD.SampleData.Models.Sales
{
    public partial class PersonCreditCard
    {
        public int BusinessEntityID { get; set; }
        public int CreditCardID { get; set; }
        public System.DateTime ModifiedDate { get; set; }

        public virtual Person Person { get; set; }
        public virtual CreditCard CreditCard { get; set; }
    }
}
