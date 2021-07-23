using System.Collections.Generic;

namespace FD.SampleData.Models.Production
{
    public partial class ScrapReason
    {
        public ScrapReason()
        {
            this.WorkOrders = new HashSet<WorkOrder>();
        }

        public short ScrapReasonID { get; set; }
        public string Name { get; set; }
        public System.DateTime ModifiedDate { get; set; }

        public virtual ICollection<WorkOrder> WorkOrders { get; set; }
    }
}
