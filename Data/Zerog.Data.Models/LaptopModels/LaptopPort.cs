namespace Zerog.Data.Models.LaptopModels
{
    using Zerog.Data.Common.Models;

    public class LaptopPort : BaseModel<int>
    {
        public int LaptopId { get; set; }

        public virtual Laptop Laptop { get; set; }

        public int PortId { get; set; }

        public virtual Port Port { get; set; }

        public int Count { get; set; }
    }
}
