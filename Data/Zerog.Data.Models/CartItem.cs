namespace Zerog.Data.Models
{
    using Zerog.Data.Common.Models;
    using Zerog.Data.Models.LaptopModels;

    public class CartItem : BaseDeletableModel<int>
    {
        public int LaptopId { get; set; }

        public virtual Laptop Laptop { get; set; }

        public int CartId { get; set; }

        public virtual Cart Cart { get; set; }

        public int Quantity { get; set; }
    }
}
