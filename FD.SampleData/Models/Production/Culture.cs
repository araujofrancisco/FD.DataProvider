using System.Collections.Generic;

namespace FD.SampleData.Models.Production
{
    public partial class Culture
    {
        public Culture()
        {
            this.ProductModelProductDescriptionCultures = new HashSet<ProductModelProductDescriptionCulture>();
        }

        public string CultureID { get; set; }
        public string Name { get; set; }
        public System.DateTime ModifiedDate { get; set; }

        public virtual ICollection<ProductModelProductDescriptionCulture> ProductModelProductDescriptionCultures { get; set; }
    }
}
