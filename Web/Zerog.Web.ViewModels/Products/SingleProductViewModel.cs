namespace Zerog.Web.ViewModels.Products
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using Zerog.Data.Models.ProductModels;
    using Zerog.Services.Mapping;

    public class SingleProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int? Discount { get; set; }

        public decimal NewPrice { get; set; }

        public string Category { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsNew { get; set; }

        public string Manufacturer { get; set; }

        public ICollection<string> Images { get; set; }

        public Dictionary<string, List<string>> Specificatons { get; set; }
    }
}
