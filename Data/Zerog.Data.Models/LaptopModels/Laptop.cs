namespace Zerog.Data.Models.LaptopModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Zerog.Data.Common.Models;

    public class Laptop : BaseDeletableModel<int>
    {
        public Laptop()
        {
            this.Images = new HashSet<Image>();
            this.Ports = new HashSet<LaptopPort>();
            this.KeyboardDetails = new HashSet<KeyboardDetail>();
            this.Extras = new HashSet<Extra>();
        }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int? Discount { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public int ManufacturerId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public int PurposeId { get; set; }

        public virtual Purpose Purpose { get; set; }

        public int ProcessorId { get; set; }

        public virtual Processor Processor { get; set; } // TODO

        public int VideoCardId { get; set; }

        public virtual VideoCard VideoCard { get; set; } // TODO

        public int MemoryId { get; set; }

        public virtual Memory Memory { get; set; } // TODO

        public int MemorySlots { get; set; }

        public int HDDId { get; set; }

        public virtual HDD HDD { get; set; } // TODO

        public int SSDId { get; set; }

        public virtual SSD SSD { get; set; } // TODO

        public int DisplayId { get; set; }

        public virtual Display Display { get; set; } // TODO

        public int CameraId { get; set; }

        public virtual Camera Camera { get; set; }

        public int AudioId { get; set; }

        public virtual Audio Audio { get; set; }

        public bool OpticalDevice { get; set; }

        public int WiFiId { get; set; }

        public virtual WiFi WiFi { get; set; }

        public int LanId { get; set; }

        public virtual Lan Lan { get; set; }

        public virtual ICollection<LaptopPort> Ports { get; set; }

        public virtual ICollection<KeyboardDetail> KeyboardDetails { get; set; }

        public virtual ICollection<Extra> Extras { get; set; }

        public int OperatingSystemId { get; set; }

        public virtual OpSystem OperatingSystem { get; set; }

        public int BatteryId { get; set; }

        public virtual Battery Battery { get; set; }

        public double Weight { get; set; }

        [Required]
        [MaxLength(50)]
        public string Demensions { get; set; }

        public int ColorId { get; set; }

        public virtual Color Color { get; set; }
    }
}
