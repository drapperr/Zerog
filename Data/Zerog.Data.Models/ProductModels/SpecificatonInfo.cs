namespace Zerog.Data.Models.ProductModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Zerog.Data.Common.Models;

    public class SpecificatonInfo : BaseModel<int>
    {
        public SpecificatonInfo()
        {
            this.ProductSpecifications = new HashSet<ProductSpecification>();
        }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        public int SpecificatonId { get; set; }

        public virtual Specificaton Specificaton { get; set; }

        public virtual ICollection<ProductSpecification> ProductSpecifications { get; set; }
    }
}
