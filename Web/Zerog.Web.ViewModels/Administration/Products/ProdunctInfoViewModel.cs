namespace Zerog.Web.ViewModels.Administration.Products
{
    using System;

    using Zerog.Data.Models.ProductModels;
    using Zerog.Services.Mapping;

    public class ProdunctInfoViewModel : IMapFrom<Product>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int? Discount { get; set; }

        public string CategoryName { get; set; }

        public string ManufacturerName { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }

        public DateTime DeletedOn { get; set; }
    }
}
