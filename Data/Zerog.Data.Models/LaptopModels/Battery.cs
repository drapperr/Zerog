namespace Zerog.Data.Models.LaptopModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Zerog.Data.Common.Models;

    public class Battery : BaseDeletableModel<int>
    {
        public Battery()
        {
            this.Laptops = new HashSet<Laptop>();
        }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public virtual ICollection<Laptop> Laptops { get; set; }
    }
}
