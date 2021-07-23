using System.Collections.Generic;

namespace FD.SampleData.Models.Production
{
    public partial class ProductDescription
    {
        public ProductDescription()
        {
            this.ProductModelProductDescriptionCultures = new HashSet<ProductModelProductDescriptionCulture>();
        }

        public int ProductDescriptionID { get; set; }
        public string Description { get; set; }
        public System.Guid rowguid { get; set; }
        public System.DateTime ModifiedDate { get; set; }

        public virtual ICollection<ProductModelProductDescriptionCulture> ProductModelProductDescriptionCultures { get; set; }
    }
}
