namespace Zerog.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using Zerog.Data.Common.Repositories;
    using Zerog.Data.Models.ProductModels;

    public class SpecificationService : ISpecificationService
    {
        private readonly IRepository<ProductSpecification> productSpecificationRepository;

        public SpecificationService(IRepository<ProductSpecification> productSpecificationRepository)
        {
            this.productSpecificationRepository = productSpecificationRepository;
        }

        public Dictionary<string, List<string>> GetAllByProductId(int id)
        {
            var result = this.productSpecificationRepository.All()
                .Where(x => x.ProductId == id)
                .Select(x => new
                {
                    SpecificationName = x.Specificaton.Name,
                    SpecificatonInfo = x.SpecificatonInfo.Name,
                }).ToList();

            var dictionary = new Dictionary<string, List<string>>();

            foreach (var item in result)
            {
                if (!dictionary.ContainsKey(item.SpecificationName))
                {
                    dictionary.Add(item.SpecificationName, new List<string>());
                }

                dictionary[item.SpecificationName].Add(item.SpecificatonInfo);
            }

            return dictionary;
        }

        public Dictionary<string, List<string>> GetAll()
        {
            var result = this.productSpecificationRepository.All()
                .Select(x => new
                {
                    SpecificationName = x.Specificaton.Name,
                    SpecificatonInfo = x.SpecificatonInfo.Name,
                }).ToList();

            var dictionary = new Dictionary<string, List<string>>();

            foreach (var item in result)
            {
                if (!dictionary.ContainsKey(item.SpecificationName))
                {
                    dictionary.Add(item.SpecificationName, new List<string>());
                }

                dictionary[item.SpecificationName].Add(item.SpecificatonInfo);
            }

            return dictionary;
        }
    }
}
