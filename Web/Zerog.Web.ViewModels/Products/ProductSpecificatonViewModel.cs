namespace Zerog.Web.ViewModels.Products
{
    using System.Collections.Generic;

    public class ProductSpecificatonViewModel
    {
        public string Name { get; set; }

        public ICollection<string> SpecificatonInfos { get; set; }
    }
}
