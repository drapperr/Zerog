namespace Zerog.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Zerog.Services.Data;
    using Zerog.Web.ViewModels.Administration.Products;

    [Area("Administration")]
    public class ProductsController : AdministrationController
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        public IActionResult Index()
        {
            var products = this.productService.GetAll<ProdunctInfoViewModel>();
            return this.View(products);
        }

        public IActionResult Create()
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
        public async Task<IActionResult> Create(CreateProductInputModel input)
        {
            if (!this.ModelState.IsValid)
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

            await this.productService.CreateAsync(input);
            return this.Redirect("/Administration/Products");
        }

        public IActionResult Edit(int id)
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
        public async Task<IActionResult> Edit(int id, CreateProductInputModel input)
        {
            await this.productService.UpdateAsync(id, input);
            return this.Redirect("/Administration/Products");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await this.productService.Delete(id);
            return this.Redirect("/Administration/Products");
        }
    }
}
