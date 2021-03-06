﻿namespace Zerog.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Zerog.Data.Common.Models;
    using Zerog.Data.Models.ProductModels;

    public class Manufacturer : BaseDeletableModel<int>
    {
        public Manufacturer()
        {
            this.Products = new HashSet<Product>();
        }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
