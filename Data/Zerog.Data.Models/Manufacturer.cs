namespace Zerog.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Zerog.Data.Common.Models;
    using Zerog.Data.Models.LaptopModels;

    public class Manufacturer : BaseDeletableModel<int>
    {
        public Manufacturer()
        {
            this.Laptops = new HashSet<Laptop>();
        }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Laptop> Laptops { get; set; }
    }
}
