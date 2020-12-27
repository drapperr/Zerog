namespace Zerog.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Zerog.Services.Data;
    using Zerog.Web.ViewModels.Products;
    using Zerog.Web.ViewModels.Reviews;

    public class ProductsController : BaseController
    {
        private readonly IProductService productService;
        private readonly IReviewService reviewService;

        public ProductsController(IProductService productService, IReviewService reviewService)
        {
            this.productService = productService;
            this.reviewService = reviewService;
        }

        [Authorize]
        public async Task<IActionResult> Create()
        {
            var productPartsDto = this.productService.GetProductParts();
            var productParts = new ProductPartsInputModel
            {
                Categories = productPartsDto.Categories,
                Manufacturers = productPartsDto.Manufacturers,
                Specifications = productPartsDto.Specifications,
            };

            var inputModel = new CreateProductInputModel
            {
                ProductParts = productParts,
            };

            return this.View(inputModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateProductInputModel input)
        {
            await this.productService.CreateAsync(input);
            return this.Redirect("/");
        }

        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            var productPartsDto = this.productService.GetProductParts();
            var productParts = new ProductPartsInputModel
            {
                Categories = productPartsDto.Categories,
                Manufacturers = productPartsDto.Manufacturers,
                Specifications = productPartsDto.Specifications,
            };

            var product = this.productService.GetById(id);

            var inputModel = new CreateProductInputModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Discount = product.Discount,
                Category = product.Category,
                Manufacturer = product.Manufacturer,
                Images = product.Images,
                Description = product.Description,
                ProductSpecifications = product.Specificatons,
                ProductParts = productParts,
            };

            return this.View(inputModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(int id, CreateProductInputModel input)
        {
            await this.productService.UpdateAsync(id, input);
            return this.Redirect("/");
        }

        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            await this.productService.Delete(id);
            return this.Redirect("/");
        }

        [Authorize]
        public async Task<IActionResult> All(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            const int ItemsPerPage = 12;
            var products = this.productService.GetAll<ProductInListViewModel>(id, ItemsPerPage);
            foreach (var product in products)
            {
                product.Stars = this.reviewService.GetAverageStars(product.Id);
            }

            var viewModel = new ProductListViewModel
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                ProductCount = this.productService.GetCount(),
                Products = products,
            };

            return this.View(viewModel);
        }

        [Authorize]
        public async Task<IActionResult> ById(int id)
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
                Description = product.Description,
                Manufacturer = product.Manufacturer,
                Specificatons = product.Specificatons,
                Reviews = this.reviewService.GetAll<SingleReviewViewModel>(id),
                Stars = this.reviewService.GetAverageStars(id),
            };

            return this.View(viewModel);
        }
    }
}
