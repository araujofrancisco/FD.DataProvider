using System.Collections.Generic;

namespace FD.SampleData.Models.Production
{
    public partial class Location
    {
        public Location()
        {
            this.ProductInventories = new HashSet<ProductInventory>();
            this.WorkOrderRoutings = new HashSet<WorkOrderRouting>();
        }

        public short LocationID { get; set; }
        public string Name { get; set; }
        public decimal CostRate { get; set; }
        public decimal Availability { get; set; }
        public System.DateTime ModifiedDate { get; set; }

        public virtual ICollection<ProductInventory> ProductInventories { get; set; }
        public virtual ICollection<WorkOrderRouting> WorkOrderRoutings { get; set; }
    }
}
