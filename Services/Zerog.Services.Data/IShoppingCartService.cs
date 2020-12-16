namespace Zerog.Services.Data
{
    using System.Threading.Tasks;

    using Zerog.Web.ViewModels.Products;

    public interface IShoppingCartService
    {
        Task AddProductAsync(string userId, int productId);

        Task<ShoppingCartViewModel> GetByUserId(string id);

        Task DeleteItem(string userId, int itemId);
    }
}
