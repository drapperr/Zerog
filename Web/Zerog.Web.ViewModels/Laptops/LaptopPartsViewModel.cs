namespace Zerog.Web.ViewModels.Laptops
{
    using System.Collections.Generic;

    public class LaptopPartsViewModel
    {
        public ICollection<string> Manufacturers { get; set; }

        public ICollection<string> Purposes { get; set; }

        public ICollection<string> Processors { get; set; }

        public ICollection<string> Memories { get; set; }

        public ICollection<string> VideoCards { get; set; }

        public ICollection<string> HDDs { get; set; }

        public ICollection<string> SSDs { get; set; }

        public ICollection<string> Displays { get; set; }

        public ICollection<string> Cameras { get; set; }

        public ICollection<string> Audios { get; set; }

        public ICollection<string> WiFis { get; set; }

        public ICollection<string> Lans { get; set; }

        public ICollection<string> Ports { get; set; }

        public ICollection<string> KeyboardDetails { get; set; }

        public ICollection<string> Extras { get; set; }

        public ICollection<string> OperatingSystems { get; set; }

        public ICollection<string> Batteries { get; set; }

        public ICollection<string> Colors { get; set; }
    }
}
