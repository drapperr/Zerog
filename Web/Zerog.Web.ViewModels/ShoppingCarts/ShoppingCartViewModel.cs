﻿namespace Zerog.Web.ViewModels.ShoppingCarts
{
    using System.Collections.Generic;
    using System.Linq;

    using Zerog.Data.Models;
    using Zerog.Services.Mapping;

    public class ShoppingCartViewModel : IMapFrom<ShoppingCart>
    {
        public ShoppingCartViewModel()
        {
            this.Items = new HashSet<ProductInCartViewModel>();
        }

        public ICollection<ProductInCartViewModel> Items { get; set; }

        public decimal Total => this.Items.Sum(x => x.ProductNewPrice * x.Quantity);
    }
}
