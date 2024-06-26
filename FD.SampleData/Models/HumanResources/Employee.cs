﻿using FD.SampleData.Models.Purchasing;
using FD.SampleData.Models.Sales;
using System;
using System.Collections.Generic;
using FD.SampleData.Models.Individual;

namespace FD.SampleData.Models.HumanResources
{
    public partial class Employee
    {
        public Employee()
        {
            this.EmployeeDepartmentHistories = new HashSet<EmployeeDepartmentHistory>();
            this.EmployeePayHistories = new HashSet<EmployeePayHistory>();
            this.JobCandidates = new HashSet<JobCandidate>();
            this.PurchaseOrderHeaders = new HashSet<PurchaseOrderHeader>();
        }

        public int BusinessEntityID { get; set; }
        public string NationalIDNumber { get; set; }
        public string LoginID { get; set; }
        public Nullable<short> OrganizationLevel { get; set; }
        public string JobTitle { get; set; }
        public System.DateTime BirthDate { get; set; }
        public string MaritalStatus { get; set; }
        public string Gender { get; set; }
        public System.DateTime HireDate { get; set; }
        public bool SalariedFlag { get; set; }
        public short VacationHours { get; set; }
        public short SickLeaveHours { get; set; }
        public bool CurrentFlag { get; set; }
        public System.Guid rowguid { get; set; }
        public System.DateTime ModifiedDate { get; set; }

        public virtual Person Person { get; set; }
        public virtual ICollection<EmployeeDepartmentHistory> EmployeeDepartmentHistories { get; set; }
        public virtual ICollection<EmployeePayHistory> EmployeePayHistories { get; set; }
        public virtual ICollection<JobCandidate> JobCandidates { get; set; }
        public virtual ICollection<PurchaseOrderHeader> PurchaseOrderHeaders { get; set; }
        public virtual SalesPerson SalesPerson { get; set; }
    }
}
