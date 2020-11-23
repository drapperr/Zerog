namespace Zerog.Data.Common.Models
{
    public class MotherboardPort : BaseModel<int>
    {
        public int MotherboardId { get; set; }

        public Motherboard Motherboard { get; set; }

        public int PortId { get; set; }

        public virtual MPort Port { get; set; }

        public int Count { get; set; }
    }
}
