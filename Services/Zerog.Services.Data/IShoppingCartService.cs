namespace Zerog.Services.Data
{
    using System.Threading.Tasks;

    using Zerog.Web.ViewModels.Laptops;

    public interface IShoppingCartService
    {
        Task AddProductAsync(string userId, int productId);

        ShoppingCartViewModel GetByUserId(string id);
    }
}
