namespace Zerog.Services.Data.Models
{
    using System.Collections.Generic;

    public class ProductPartsDto
    {
        public ICollection<string> Manufacturers { get; set; }

        public ICollection<string> Categories { get; set; }

        public Dictionary<string, List<string>> Specifications { get; set; }
    }
}
