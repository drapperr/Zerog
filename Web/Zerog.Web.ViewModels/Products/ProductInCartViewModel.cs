namespace Zerog.Web.ViewModels.Products
{
    using Zerog.Data.Models;
    using Zerog.Services.Mapping;

    public class ProductInCartViewModel : IMapFrom<ShoppingCartItem>
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public decimal ProductNewPrice { get; set; }

        public int Quantity { get; set; }
    }
}
