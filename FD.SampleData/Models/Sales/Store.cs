﻿using FD.SampleData.Models.Individual;
using System;
using System.Collections.Generic;

namespace FD.SampleData.Models.Sales
{
    public partial class Store
    {
        public Store()
        {
            this.Customers = new HashSet<Customer>();
        }

        public int BusinessEntityID { get; set; }
        public string Name { get; set; }
        public Nullable<int> SalesPersonID { get; set; }
        public string Demographics { get; set; }
        public System.Guid rowguid { get; set; }
        public System.DateTime ModifiedDate { get; set; }

        public virtual BusinessEntity BusinessEntity { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual SalesPerson SalesPerson { get; set; }
    }
}
