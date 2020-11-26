namespace Zerog.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Zerog.Data.Common.Models;
    using Zerog.Data.Models.LaptopModels;

    public class Category : BaseDeletableModel<int>
    {
        [Required]
        public string Name { get; set; }

        public ICollection<Laptop> Laptops { get; set; }
    }
}
