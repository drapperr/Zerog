namespace Zerog.Web.ViewModels.Laptops
{
    using System.Collections.Generic;

    public class LaptopDtoModel
    {
        public string Name { get; set; }

        public string Manufacturer { get; set; }

        public decimal Price { get; set; }

        public ICollection<string> Images { get; set; }

        public string Purpose { get; set; }

        public string Processor { get; set; }

        public string VideoCard { get; set; }

        public string Memory { get; set; }

        public int MemorySlots { get; set; }

        public string HDD { get; set; }

        public string SSD { get; set; }

        public string Display { get; set; }

        public string Camera { get; set; }

        public string Audio { get; set; }

        public bool OpticalDevice { get; set; }

        public string WiFi { get; set; }

        public string Lan { get; set; }

        public ICollection<PortDtoModel> Ports { get; set; }

        public ICollection<string> KeyboardDetails { get; set; }

        public ICollection<string> Extras { get; set; }

        public string OperatingSystem { get; set; }

        public string Battery { get; set; }

        public double Weight { get; set; }

        public string Demensions { get; set; }

        public string Color { get; set; }
    }
}
