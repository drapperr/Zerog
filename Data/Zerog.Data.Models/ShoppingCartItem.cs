namespace Zerog.Data.Models
{
    using Zerog.Data.Common.Models;
    using Zerog.Data.Models.LaptopModels;

    public class ShoppingCartItem : BaseDeletableModel<int>
    {
        public int LaptopId { get; set; }

        public virtual Laptop Laptop { get; set; }

        public int CartId { get; set; }

        public virtual ShoppingCart ShoppingCart { get; set; }

        public int Quantity { get; set; }
    }
}
