namespace Zerog.Web.ViewModels.Orders
{
    public class ProductInOrderViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal Total { get; set; }
    }
}