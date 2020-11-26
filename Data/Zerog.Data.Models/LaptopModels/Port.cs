namespace Zerog.Data.Models.LaptopModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Zerog.Data.Common.Models;

    public class Port : BaseDeletableModel<int>
    {
        public Port()
        {
            this.LaptopPorts = new HashSet<LaptopPort>();
        }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<LaptopPort> LaptopPorts { get; set; }
    }
}
