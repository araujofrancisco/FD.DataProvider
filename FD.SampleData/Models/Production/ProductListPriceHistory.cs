﻿using System;

namespace FD.SampleData.Models.Production
{
    public partial class ProductListPriceHistory
    {
        public int ProductID { get; set; }
        public System.DateTime StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public decimal ListPrice { get; set; }
        public System.DateTime ModifiedDate { get; set; }

        public virtual Product Product { get; set; }
    }
}
