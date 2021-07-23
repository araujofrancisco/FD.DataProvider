using FD.SampleData.Models.Production;

namespace FD.SampleData.Models.Sales
{
    public partial class ShoppingCartItem
    {
        public int ShoppingCartItemID { get; set; }
        public string ShoppingCartID { get; set; }
        public int Quantity { get; set; }
        public int ProductID { get; set; }
        public System.DateTime DateCreated { get; set; }
        public System.DateTime ModifiedDate { get; set; }

        public virtual Product Product { get; set; }
    }
}
