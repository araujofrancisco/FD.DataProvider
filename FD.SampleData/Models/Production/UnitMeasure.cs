using FD.SampleData.Models.Purchasing;
using System.Collections.Generic;

namespace FD.SampleData.Models.Production
{
    public partial class UnitMeasure
    {
        public UnitMeasure()
        {
            this.BillOfMaterials = new HashSet<BillOfMaterial>();
            this.Products = new HashSet<Product>();
            this.Products1 = new HashSet<Product>();
            this.ProductVendors = new HashSet<ProductVendor>();
        }

        public string UnitMeasureCode { get; set; }
        public string Name { get; set; }
        public System.DateTime ModifiedDate { get; set; }

        public virtual ICollection<BillOfMaterial> BillOfMaterials { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Product> Products1 { get; set; }
        public virtual ICollection<ProductVendor> ProductVendors { get; set; }
    }
}
