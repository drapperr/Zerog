namespace Zerog.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Zerog.Data.Common.Repositories;
    using Zerog.Data.Models;
    using Zerog.Data.Models.ProductModels;
    using Zerog.Services.Data.Models;
    using Zerog.Services.Mapping;

    public class ProductService : IProductService
    {
        private readonly IDeletableEntityRepository<Product> productRepository;
        private readonly IDeletableEntityRepository<Manufacturer> manufacturerRepository;
        private readonly IDeletableEntityRepository<Category> categoryRepository;
        private readonly ISpecificationService specificationService;

        public ProductService(
            IDeletableEntityRepository<Product> productRepository,
            IDeletableEntityRepository<Manufacturer> manufacturerRepository,
            IDeletableEntityRepository<Category> categoryRepository,
            ISpecificationService specificationService)
        {
            this.productRepository = productRepository;
            this.manufacturerRepository = manufacturerRepository;
            this.categoryRepository = categoryRepository;
            this.specificationService = specificationService;
        }

        public async Task CreateAsync(CreateProductDto input)
        {
            var categoryId = await this.GetOrCreateCategory("Laptop");

            var manufacturerId = await this.GetOrCreateManufacturer(input.Manufacturer);

            var laptop = new Product
            {
                Name = input.Name,
                CategoryId = categoryId,
                ManufacturerId = manufacturerId,
                Price = input.Price,
                Images = input.Images.Select(x => new Image { Url = x }).ToList(),
            };

            await this.productRepository.AddAsync(laptop);
            await this.productRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 12)
        {
            var products = this.productRepository.AllAsNoTracking()
               .OrderByDescending(x => x.Id)
               .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
               .To<T>().ToList();
            return products;
        }

        public SingleProductDto GetById(int id)
        {
            var specifications = this.specificationService.GetAllByProductId(id);

            var product = this.productRepository.AllAsNoTracking()
                 .Where(x => x.Id == id)
                 .Select(x => new SingleProductDto
                 {
                     Id = x.Id,
                     Name = x.Name,
                     Price = x.Price,
                     Discount = x.Discount,
                     Category = x.Category.Name,
                     CreatedOn = x.CreatedOn,
                     Manufacturer = x.Manufacturer.Name,
                     Images = x.Images.Select(x => x.Url).ToList(),
                     Specificatons = specifications,
                 }).FirstOrDefault();

            return product;
        }

        public int GetCount()
        {
            return this.productRepository.All().Count();
        }

        private async Task<int> GetOrCreateCategory(string categoryName)
        {
            var category = this.categoryRepository.All()
                   .FirstOrDefault(x => x.Name == categoryName);

            if (category is null)
            {
                category = new Category { Name = categoryName };
                await this.categoryRepository.AddAsync(category);
                await this.categoryRepository.SaveChangesAsync();
            }

            return category.Id;
        }

        private async Task<int> GetOrCreateManufacturer(string manufacturerName)
        {
            var manufacturer = this.manufacturerRepository.All()
                .FirstOrDefault(x => x.Name == manufacturerName);

            if (manufacturer is null)
            {
                manufacturer = new Manufacturer { Name = manufacturerName };
                await this.manufacturerRepository.AddAsync(manufacturer);
                await this.manufacturerRepository.SaveChangesAsync();
            }

            return manufacturer.Id;
        }
    }
}
