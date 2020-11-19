namespace Zerog.Web.ViewModels
{
    using System.Collections.Generic;

    public class MotherboardDtoModel
    {
        public string Name { get; set; }

        public string Manufacturer { get; set; }

        public decimal Price { get; set; }

        public ICollection<string> Images { get; set; }

        public string Socket { get; set; }

        public string Chipset { get; set; }

        public ICollection<string> SupportedProcessors { get; set; }

        public string MemoryType { get; set; }

        public int MemorySpeed { get; set; }

        public int MemorySlots { get; set; }

        public string SoundCard { get; set; }

        public string LanCard { get; set; }

        public ICollection<NameCountDtoModel> Interfaces { get; set; }

        public ICollection<NameCountDtoModel> Ports { get; set; }

        public string FormFactor { get; set; }

        public string Demensions { get; set; }
    }
}
