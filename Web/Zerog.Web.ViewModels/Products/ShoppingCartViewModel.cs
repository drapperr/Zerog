namespace Zerog.Web.ViewModels.Products
{
    using System.Collections.Generic;

    public class ShoppingCartViewModel
    {
        public ShoppingCartViewModel()
        {
            this.Items = new HashSet<ProductInCartViewModel>();
        }

        public ICollection<ProductInCartViewModel> Items { get; set; }

        public decimal Total { get; set; }
    }
}
