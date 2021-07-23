using System.Collections.Generic;

namespace FD.SampleData.Models.Production
{
    public partial class ProductCategory
    {
        public ProductCategory()
        {
            this.ProductSubcategories = new HashSet<ProductSubcategory>();
        }

        public int ProductCategoryID { get; set; }
        public string Name { get; set; }
        public System.Guid rowguid { get; set; }
        public System.DateTime ModifiedDate { get; set; }

        public virtual ICollection<ProductSubcategory> ProductSubcategories { get; set; }
    }
}
