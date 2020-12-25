namespace Zerog.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Zerog.Web.ViewModels.Products;

    public interface IProductService
    {
        Task CreateAsync(CreateProductInputModel input);

        IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 12);

        int GetCount();

        SingleProductViewModel GetById(int id);

        ProductPartsInputModel GetProductParts();

        Task UpdateAsync(int id, CreateProductInputModel input);

        Task Delete(int id);
    }
}
