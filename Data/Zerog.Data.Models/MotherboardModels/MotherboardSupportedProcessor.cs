namespace Zerog.Data.Common.Models
{
    public class MotherboardSupportedProcessor : BaseModel<int>
    {
        public int MotherboardId { get; set; }

        public Motherboard Motherboard { get; set; }

        public int SupportedProcessorId { get; set; }

        public SupportedProcessor SupportedProcessor { get; set; }
    }
}
