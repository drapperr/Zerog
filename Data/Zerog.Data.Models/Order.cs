namespace Zerog.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Zerog.Data.Common.Models;

    public class Order : BaseDeletableModel<int>
    {
        public Order()
        {
            this.OrderStatus = 1;
            this.Items = new HashSet<OrderItem>();
        }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<OrderItem> Items { get; set; }

        public int OrderStatus { get; set; }

        [MaxLength(450)]
        public string PaymentMethod { get; set; }
    }
}
