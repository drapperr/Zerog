namespace Zerog.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IWishListService
    {
        Task AddProductAsync(string userId, int productId);

        Task RemoveProduct(string userId, int productId);

        ICollection<T> GetAllProductsAsync<T>(string userId);

        int GetAllProductsCount(string userId);
    }
}
