namespace Zerog.Services.Data.Models
{
    using System.Collections.Generic;

    public class ProductSpecificationDto
    {
        public string Name { get; set; }

        public ICollection<string> SpecificatonInfos { get; set; }
    }
}
