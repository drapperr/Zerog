namespace Zerog.Data.Common.Models
{
    public class MotherboardPorts : BaseModel<int>
    {
        public int MotherboardId { get; set; }

        public Motherboard Motherboard { get; set; }

        public int PortId { get; set; }

        public Port Port { get; set; }

        public int Count { get; set; }
    }
}
