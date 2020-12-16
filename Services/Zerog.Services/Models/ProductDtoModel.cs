namespace Zerog.Services.Models
{
    using System.Collections.Generic;

    public class ProductDtoModel
    {
        public ProductDtoModel()
        {
            this.Images = new List<string>();
            this.Specifications = new List<SpecificationDtoModel>();
        }

        public string Name { get; set; }

        public string Manufacturer { get; set; }

        public string Category { get; set; }

        public decimal Price { get; set; }

        public List<string> Images { get; set; }

        public List<SpecificationDtoModel> Specifications { get; set; }
    }
}
