﻿namespace Zerog.Data.Models.ProductModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Zerog.Data.Common.Models;

    public class Product : BaseDeletableModel<int>
    {
        public Product()
        {
            this.Images = new HashSet<Image>();
            this.ProductSpecifications = new HashSet<ProductSpecification>();
        }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int? Discount { get; set; }

        public decimal NewPrice => this.Discount == null ? this.Price : (this.Price - (this.Price * ((decimal)this.Discount / 100)));

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public int ManufacturerId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public virtual ICollection<ProductSpecification> ProductSpecifications { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }
    }
}
