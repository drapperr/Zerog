namespace Zerog.Web.ViewModels.Laptops
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ShoppingCartViewModel
    {
        public ShoppingCartViewModel()
        {
            this.Items = new HashSet<LaptopInCartViewModel>();
        }

        public ICollection<LaptopInCartViewModel> Items { get; set; }

        public decimal Total { get; set; }
    }
}
