namespace Zerog.Web.Controllers
{
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Zerog.Services.Data;
    using Zerog.Web.ViewModels.Laptops;

    public class ShoppingCartsController : BaseController
    {
        private readonly IShoppingCartService shoppingCartService;

        public ShoppingCartsController(IShoppingCartService shoppingCartService)
        {
            this.shoppingCartService = shoppingCartService;
        }

        [Authorize]
        public async Task<IActionResult> AddProduct(int id)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            await this.shoppingCartService.AddProductAsync(userId, id);

            return this.Redirect("/ShoppingCarts/MyCart");
        }

        [Authorize]
        public IActionResult MyCart(int id)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var cart = this.shoppingCartService.GetByUserId(userId);

            return this.View(cart);
        }
    }
}
