namespace Zerog.Data.Models
{
    using Zerog.Data.Common.Models;
    using Zerog.Data.Models.ProductModels;

    public class OrderItem : BaseDeletableModel<int>
    {
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public int OrderId { get; set; }

        public virtual Order Order { get; set; }

        public int Quantity { get; set; }
    }
}
