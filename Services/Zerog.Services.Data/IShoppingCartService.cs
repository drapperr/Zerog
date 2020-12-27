namespace Zerog.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using Zerog.Data.Models;

    public interface IShoppingCartService
    {
        Task AddProductAsync(string userId, int productId);

        Task<T> GetByUserId<T>(string id);

        Task DeleteItem(string userId, int itemId);

        Task ClearItems(string userId);
    }
}
