namespace Zerog.Data.Models
{
    using System.Collections.Generic;

    using Zerog.Data.Common.Models;

    public class Cart : BaseDeletableModel<int>
    {
        public Cart()
        {
            this.Items = new HashSet<CartItem>();
        }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<CartItem> Items { get; set; }
    }
}
