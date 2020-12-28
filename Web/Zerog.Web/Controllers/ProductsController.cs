namespace Zerog.Web.Controllers
{
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

        public IActionResult All(int id = 1)
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
