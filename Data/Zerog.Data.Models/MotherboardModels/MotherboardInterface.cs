namespace Zerog.Data.Common.Models
{
    public class MotherboardInterface : BaseModel<int>
    {
        public int MotherboardId { get; set; }

        public Motherboard Motherboard { get; set; }

        public int InterfaceId { get; set; }

        public Interface Interface { get; set; }

        public int Count { get; set; }
    }
}
