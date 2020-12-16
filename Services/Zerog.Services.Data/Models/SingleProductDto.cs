namespace Zerog.Services.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class SingleProductDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int? Discount { get; set; }

        public decimal NewPrice => this.Discount == null ? this.Price : this.Price - (this.Price * ((decimal)this.Discount / 100));

        public string Category { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsNew => (DateTime.UtcNow - this.CreatedOn).Days < 30;

        public string Manufacturer { get; set; }

        public ICollection<string> Images { get; set; }

        public Dictionary<string, List<string>> Specificatons { get; set; }

    }
}
