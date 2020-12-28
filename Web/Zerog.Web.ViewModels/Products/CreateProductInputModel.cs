namespace Zerog.Web.ViewModels.Products
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CreateProductInputModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        public string Name { get; set; }

        [Range(0, 100000)]
        public decimal Price { get; set; }

        [Range(0, 100)]
        public int? Discount { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(50)]
        public string Category { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(50)]
        public string Manufacturer { get; set; }

        public ICollection<string> Images { get; set; }

        public Dictionary<string, List<string>> ProductSpecifications { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        public ProductPartsInputModel ProductParts { get; set; }
    }
}
