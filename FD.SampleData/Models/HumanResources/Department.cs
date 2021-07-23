using System.Collections.Generic;

namespace FD.SampleData.Models.HumanResources
{
    public partial class Department
    {
        public Department()
        {
            this.EmployeeDepartmentHistories = new HashSet<EmployeeDepartmentHistory>();
        }

        public short DepartmentID { get; set; }
        public string Name { get; set; }
        public string GroupName { get; set; }
        public System.DateTime ModifiedDate { get; set; }

        public virtual ICollection<EmployeeDepartmentHistory> EmployeeDepartmentHistories { get; set; }
    }
}
