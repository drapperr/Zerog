namespace Zerog.Services.Models
{
    using System.Collections.Generic;

    public class SpecificationDtoModel
    {
        public SpecificationDtoModel()
        {
            this.Values = new List<string>();
        }

        public string Name { get; set; }

        public List<string> Values { get; set; }
    }
}
