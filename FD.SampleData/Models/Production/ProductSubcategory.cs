﻿using System.Collections.Generic;

namespace FD.SampleData.Models.Production
{
    public partial class ProductSubcategory
    {
        public ProductSubcategory()
        {
            this.Products = new HashSet<Product>();
        }

        public int ProductSubcategoryID { get; set; }
        public int ProductCategoryID { get; set; }
        public string Name { get; set; }
        public System.Guid rowguid { get; set; }
        public System.DateTime ModifiedDate { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
    }
}
