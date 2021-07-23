namespace FD.SampleData.Models.Production
{
    public partial class ProductDocument
    {
        public int ProductID { get; set; }
        public System.DateTime ModifiedDate { get; set; }

        public virtual Product Product { get; set; }
    }
}
