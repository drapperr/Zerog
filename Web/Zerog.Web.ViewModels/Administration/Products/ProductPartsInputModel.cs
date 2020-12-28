namespace Zerog.Web.ViewModels.Administration.Products
{
    using System.Collections.Generic;

    public class ProductPartsInputModel
    {
        public ICollection<string> Manufacturers { get; set; }

        public ICollection<string> Categories { get; set; }

        public Dictionary<string, List<string>> Specifications { get; set; }
    }
}