namespace FD.SampleData.Models.HumanResources
{
    public partial class EmployeePayHistory
    {
        public int BusinessEntityID { get; set; }
        public System.DateTime RateChangeDate { get; set; }
        public decimal Rate { get; set; }
        public byte PayFrequency { get; set; }
        public System.DateTime ModifiedDate { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
