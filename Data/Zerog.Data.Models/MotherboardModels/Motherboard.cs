namespace Zerog.Data.Common.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Motherboard : BaseDeletableModel<int>
    {
        public Motherboard()
        {
            this.Images = new HashSet<MotherboardImage>();
            this.SupportedProcessors = new HashSet<MotherboardSupportedProcessor>();
            this.Interfaces = new HashSet<MotherboardInterface>();
            this.Ports = new HashSet<MotherboardPort>();
        }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public int ManufacturerId { get; set; }

        public virtual MotherboardManufacturer Manufacturer { get; set; }

        public decimal Price { get; set; }

        public virtual ICollection<MotherboardImage> Images { get; set; }

        public int SocketId { get; set; }

        public virtual Sockets Socket { get; set; }

        public int ChipsetId { get; set; }

        public virtual Chipset Chipset { get; set; }

        public virtual ICollection<MotherboardSupportedProcessor> SupportedProcessors { get; set; }

        public int MemoryTypeId { get; set; }

        public virtual MemoryType MemoryType { get; set; }

        public int MemorySpeed { get; set; }

        public int MemorySlots { get; set; }

        public int SoundCardId { get; set; }

        public virtual SoundCard SoundCard { get; set; }

        public int LanCardId { get; set; }

        public virtual LanCard LanCard { get; set; }

        public virtual ICollection<MotherboardInterface> Interfaces { get; set; }

        public virtual ICollection<MotherboardPort> Ports { get; set; }

        public int FormFactorId { get; set; }

        public virtual FormFactor FormFactor { get; set; }

        [Required]
        [MaxLength(50)]
        public string Demensions { get; set; }
    }
}
