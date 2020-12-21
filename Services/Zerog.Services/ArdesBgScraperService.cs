namespace Zerog.Services
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using Newtonsoft.Json;
    using Zerog.Data.Common.Repositories;
    using Zerog.Data.Models;
    using Zerog.Data.Models.ProductModels;
    using Zerog.Services.Models;

    public class ArdesBgScraperService : IArdesBgScraperService
    {
        private readonly IDeletableEntityRepository<Product> productRepository;
        private readonly IDeletableEntityRepository<Manufacturer> manufacturerRepository;
        private readonly IDeletableEntityRepository<Category> categoryRepository;
        private readonly IRepository<Specificaton> specificationRepository;
        private readonly IRepository<SpecificatonInfo> specificatonInfoRepository;
        private readonly IRepository<ProductSpecification> productSpecificationRepository;

        public ArdesBgScraperService(
            IDeletableEntityRepository<Product> productRepository,
            IDeletableEntityRepository<Manufacturer> manufacturerRepository,
            IDeletableEntityRepository<Category> categoryRepository,
            IRepository<Specificaton> specificationRepository,
            IRepository<SpecificatonInfo> specificatonInfoRepository,
            IRepository<ProductSpecification> productSpecificationRepository)
        {
            this.productRepository = productRepository;
            this.manufacturerRepository = manufacturerRepository;
            this.categoryRepository = categoryRepository;
            this.specificationRepository = specificationRepository;
            this.specificatonInfoRepository = specificatonInfoRepository;
            this.productSpecificationRepository = productSpecificationRepository;
        }

        public async Task ImportPorductsAsync()
        {
            var json = File.ReadAllText("C:/Users/User/OneDrive/Desktop/Projects/ArdesScraper/ArdesScraper/JsonsData/products.json");
            var productModels = JsonConvert.DeserializeObject<List<ProductDtoModel>>(json);

            foreach (var product in productModels)
            {
                await this.AddAsync(product);
            }
        }

        public async Task AddAsync(ProductDtoModel input)
        {
            var categoryId = await this.GetOrCreateCategory(input.Category);

            var manufacturerId = await this.GetOrCreateManufacturer(input.Manufacturer);

            var product = new Product
            {
                Name = input.Name,
                CategoryId = categoryId,
                ManufacturerId = manufacturerId,
                Price = input.Price,
                Images = input.Images.Select(x => new Image { Url = x }).ToList(),
            };

            await this.productRepository.AddAsync(product);
            await this.productRepository.SaveChangesAsync();

            foreach (var specificationDto in input.Specifications)
            {
                var specificationId = await this.GetOrCreateSpecification(specificationDto.Name);

                foreach (var name in specificationDto.Values)
                {
                    var specificatonInfoId = await this.GetOrCreateSpecificationInfo(name, specificationId);

                    await this.AddProductSpecification(product.Id, specificationId, specificatonInfoId);
                }
            }
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
    }
}
