namespace Zerog.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Zerog.Services.Data.Models;

    public interface IProductService
    {
        Task CreateAsync(CreateProductDto input);

        IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 12);

        int GetCount();

        SingleProductDto GetById(int id);

        ProductPartsDto GetProductParts();
    }
}
