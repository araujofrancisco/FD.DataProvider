using System.Collections.Generic;

namespace FD.SampleData.Models.Production
{
    public partial class Illustration
    {
        public Illustration()
        {
            this.ProductModelIllustrations = new HashSet<ProductModelIllustration>();
        }

        public int IllustrationID { get; set; }
        public string Diagram { get; set; }
        public System.DateTime ModifiedDate { get; set; }

        public virtual ICollection<ProductModelIllustration> ProductModelIllustrations { get; set; }
    }
}
