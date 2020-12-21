using System;
using System.Collections.Generic;
using System.Text;

namespace Zerog.Services.Data.Models
{
    public class CreateProductDto
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int? Discount { get; set; }

        public string Category { get; set; }

        public string Manufacturer { get; set; }

        public ICollection<string> Images { get; set; }

        public Dictionary<string, List<string>> ProductSpecifications { get; set; }

        public string Description { get; set; }
    }
}
