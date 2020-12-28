namespace Zerog.Data.Models.ProductModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Zerog.Data.Common.Models;

    public class Specificaton : BaseModel<int>
    {
        public Specificaton()
        {
            this.ProductSpecifications = new HashSet<ProductSpecification>();
            this.SpecificatonInfos = new HashSet<SpecificatonInfo>();
        }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public virtual ICollection<ProductSpecification> ProductSpecifications { get; set; }

        public virtual ICollection<SpecificatonInfo> SpecificatonInfos { get; set; }
    }
}
