namespace Zerog.Services.Data
{
    using System.Threading.Tasks;

    public interface IShoppingCartService
    {
        Task AddProductAsync(string userId, int productId);

        Task<T> GetByUserId<T>(string id);

        Task DeleteItem(string userId, int itemId);
    }
}
