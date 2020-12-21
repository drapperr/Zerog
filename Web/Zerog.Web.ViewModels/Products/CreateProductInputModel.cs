namespace Zerog.Web.ViewModels.Products
{
    using System.Collections.Generic;

    public class CreateProductInputModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int? Discount { get; set; }

        public string Category { get; set; }

        public string Manufacturer { get; set; }

        public ICollection<string> Images { get; set; }

        public Dictionary<string, List<string>> ProductSpecifications { get; set; }

        public string Description { get; set; }

        public ProductPartsInputModel ProductParts { get; set; }
    }
}
