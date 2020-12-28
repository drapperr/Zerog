namespace Zerog.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Zerog.Data.Common.Repositories;
    using Zerog.Data.Models;
    using Zerog.Data.Models.ProductModels;
    using Zerog.Services.Mapping;
    using Zerog.Web.ViewModels.Administration.Products;
    using Zerog.Web.ViewModels.Products;

    public class ProductService : IProductService
    {
        private readonly IDeletableEntityRepository<Product> productRepository;
        private readonly IDeletableEntityRepository<Manufacturer> manufacturerRepository;
        private readonly IDeletableEntityRepository<Category> categoryRepository;
        private readonly IRepository<Image> imageRepository;
        private readonly IRepository<Specificaton> specificationRepository;
        private readonly IRepository<SpecificatonInfo> specificatonInfoRepository;
        private readonly IRepository<ProductSpecification> productSpecificationRepository;
        private readonly ISpecificationService specificationService;

        public ProductService(
            IDeletableEntityRepository<Product> productRepository,
            IDeletableEntityRepository<Manufacturer> manufacturerRepository,
            IDeletableEntityRepository<Category> categoryRepository,
            IRepository<Image> imageRepository,
            IRepository<Specificaton> specificationRepository,
            IRepository<SpecificatonInfo> specificatonInfoRepository,
            IRepository<ProductSpecification> productSpecificationRepository,
            ISpecificationService specificationService)
        {
            this.productRepository = productRepository;
            this.manufacturerRepository = manufacturerRepository;
            this.categoryRepository = categoryRepository;
            this.imageRepository = imageRepository;
            this.specificationRepository = specificationRepository;
            this.specificatonInfoRepository = specificatonInfoRepository;
            this.productSpecificationRepository = productSpecificationRepository;
            this.specificationService = specificationService;
        }

        public async Task CreateAsync(CreateProductInputModel input)
        {
            var categoryId = await this.GetOrCreateCategory(input.Category);

            var manufacturerId = await this.GetOrCreateManufacturer(input.Manufacturer);

            var productSpecifications = new List<ProductSpecification>();

            var product = new Product
            {
                Name = input.Name,
                CategoryId = categoryId,
                ManufacturerId = manufacturerId,
                Discount = input.Discount,
                Price = input.Price,
                Description = input.Description,
            };

            await this.productRepository.AddAsync(product);
            await this.productRepository.SaveChangesAsync();

            await this.AddImages(product.Id, input.Images);

            foreach (var (key, value) in input.ProductSpecifications)
            {
                var specificationId = await this.GetOrCreateSpecification(key);

                foreach (var item in value)
                {
                    if (string.IsNullOrEmpty(item))
                    {
                        continue;
                    }

                    var specificatonInfoId = await this.GetOrCreateSpecificationInfo(item, specificationId);

                    await this.AddProductSpecification(product.Id, specificationId, specificatonInfoId);
                }
            }
        }

        private async Task AddImages(int id, ICollection<string> images)
        {
            foreach (var url in images)
            {
                var newImage = new Image
                {
                    Url = url,
                    ProductId = id,
                };

                await this.imageRepository.AddAsync(newImage);
                await this.imageRepository.SaveChangesAsync();
            }
        }

        public IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 12)
        {
            var products = this.productRepository.AllAsNoTracking()
               .OrderByDescending(x => x.Id)
               .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
               .To<T>().ToList();
            return products;
        }

        public SingleProductViewModel GetById(int id)
        {
            var specifications = this.specificationService.GetAllByProductId(id);

            var product = this.productRepository.AllAsNoTracking()
                 .Where(x => x.Id == id)
                 .Select(x => new SingleProductViewModel
                 {
                     Id = x.Id,
                     Name = x.Name,
                     Price = x.Price,
                     Discount = x.Discount,
                     NewPrice = x.NewPrice,
                     Category = x.Category.Name,
                     CreatedOn = x.CreatedOn,
                     Manufacturer = x.Manufacturer.Name,
                     Images = x.Images.Select(x => x.Url).ToList(),
                     Specificatons = specifications,
                     Description = x.Description,
                 }).FirstOrDefault();

            return product;
        }

        public int GetCount()
        {
            return this.productRepository.All().Count();
        }

        public ProductPartsInputModel GetProductParts()
        {
            var categories = this.categoryRepository.AllAsNoTracking().Select(x => x.Name).ToList();
            var manufacturers = this.manufacturerRepository.AllAsNoTracking().Select(x => x.Name).ToList();
            var specifications = this.specificationService.GetAll();

            var productParts = new ProductPartsInputModel
            {
                Categories = categories,
                Manufacturers = manufacturers,
                Specifications = specifications,
            };

            return productParts;
        }

        private async Task AddProductSpecification(int productId, int specificationId, int specificatonInfoId)
        {
            var poductSpecification = new ProductSpecification
            {
                ProductId = productId,
                SpecificatonId = specificationId,
                SpecificatonInfoId = specificatonInfoId,
            };

            await this.productSpecificationRepository.AddAsync(poductSpecification);
            await this.productSpecificationRepository.SaveChangesAsync();
        }

        private async Task<int> GetOrCreateSpecificationInfo(string specificationInfoName, int specificatonId)
        {
            var specificationInfo = this.specificatonInfoRepository.All()
                   .FirstOrDefault(x => x.Name == specificationInfoName && x.SpecificatonId == specificatonId);

            if (specificationInfo is null)
            {
                specificationInfo = new SpecificatonInfo
                {
                    Name = specificationInfoName,
                    SpecificatonId = specificatonId,
                };
                await this.specificatonInfoRepository.AddAsync(specificationInfo);
                await this.specificatonInfoRepository.SaveChangesAsync();
            }

            return specificationInfo.Id;
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

        private async Task<int> GetOrCreateSpecification(string specificationName)
        {
            var specification = this.specificationRepository.All()
                .FirstOrDefault(x => x.Name == specificationName);

            if (specification is null)
            {
                specification = new Specificaton { Name = specificationName };
                await this.specificationRepository.AddAsync(specification);
                await this.specificationRepository.SaveChangesAsync();
            }

            return specification.Id;
        }

        public async Task Delete(int id)
        {
            var product = this.productRepository.All().FirstOrDefault(x => x.Id == id);

            this.productRepository.Delete(product);

            await this.productRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, CreateProductInputModel input)
        {
            var product = this.productRepository.All().FirstOrDefault(x => x.Id == id);

            var categoryId = await this.GetOrCreateCategory(input.Category);

            var manufacturerId = await this.GetOrCreateManufacturer(input.Manufacturer);

            var productSpecifications = new List<ProductSpecification>();

            product.Name = input.Name;
            product.CategoryId = categoryId;
            product.ManufacturerId = manufacturerId;
            product.Discount = input.Discount;
            product.Price = input.Price;
            product.Description = input.Description;

            this.ClearImages(product.Id);

            await this.AddImages(product.Id, input.Images);

            this.ClearSpecifications(product.Id);

            foreach (var (key, value) in input.ProductSpecifications)
            {
                var specificationId = await this.GetOrCreateSpecification(key);

                foreach (var item in value)
                {
                    if (string.IsNullOrEmpty(item))
                    {
                        continue;
                    }

                    var specificatonInfoId = await this.GetOrCreateSpecificationInfo(item, specificationId);

                    await this.AddProductSpecification(product.Id, specificationId, specificatonInfoId);
                }
            }

            await this.productRepository.SaveChangesAsync();
        }

        private void ClearImages(int id)
        {
            foreach (var item in this.imageRepository.All().Where(x => x.ProductId == id).ToList())
            {
                this.imageRepository.Delete(item);
            }
        }

        private void ClearSpecifications(int id)
        {
            foreach (var item in this.productSpecificationRepository.All().Where(x => x.ProductId == id).ToList())
            {
                this.productSpecificationRepository.Delete(item);
            }
        }

        public IEnumerable<T> GetAll<T>()
        {
            var products = this.productRepository.AllAsNoTracking()
               .OrderByDescending(x => x.Id)
               .To<T>().ToList();

            return products;
        }
    }
}
