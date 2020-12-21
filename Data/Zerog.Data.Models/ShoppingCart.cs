namespace Zerog.Data.Models
{
    using System.Collections.Generic;
    using System.Linq;

    using Zerog.Data.Common.Models;

    public class ShoppingCart : BaseModel<int>
    {
        public ShoppingCart()
        {
            this.Items = new HashSet<ShoppingCartItem>();
        }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<ShoppingCartItem> Items { get; set; }
    }
}
