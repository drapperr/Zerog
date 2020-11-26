namespace Zerog.Web.ViewModels.Laptops
{
    using System.Collections.Generic;

    public class LaptopListViewModel : PagingViewModel
    {
        public IEnumerable<LaptopInListViewModel> Laptops { get; set; }
    }
}
