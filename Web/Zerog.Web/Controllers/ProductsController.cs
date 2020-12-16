namespace Zerog.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Zerog.Services.Data;
    using Zerog.Web.ViewModels.Products;

    public class ProductsController : BaseController
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        public IActionResult Create()
        {
            var inputModel = new CreateProductInputModel { };
            return this.View(inputModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductInputModel input)
        {
            // await this.productService.CreateAsync(input);
            return this.Redirect("/");
        }

        public IActionResult All(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            const int ItemsPerPage = 12;
            var viewModel = new ProductListViewModel
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                ProductCount = this.productService.GetCount(),
                Products = this.productService.GetAll<ProductInListViewModel>(id, ItemsPerPage),
            };

            return this.View(viewModel);
        }

        public IActionResult ById(int id)
        {
            var product = this.productService.GetById(id);

            var viewModel = new SingleProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Discount = product.Discount,
                NewPrice = product.NewPrice,
                Category = product.Category,
                Images = product.Images,
                IsNew = product.IsNew,
                Manufacturer = product.Manufacturer,
                Specificatons = product.Specificatons,
            };

            return this.View(viewModel);
        }
    }
}
