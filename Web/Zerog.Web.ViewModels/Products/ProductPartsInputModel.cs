namespace Zerog.Web.ViewModels.Products
{
    using System.Collections.Generic;

    using Zerog.Services.Data.Models;
    using Zerog.Services.Mapping;

    public class ProductPartsInputModel : IMapFrom<ProductPartsDto>
    {
        public ICollection<string> Manufacturers { get; set; }

        public ICollection<string> Categories { get; set; }

        public Dictionary<string, List<string>> Specifications { get; set; }
    }
}