namespace Zerog.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Zerog.Services.Data;
    using Zerog.Web.ViewModels.Products;
    using Zerog.Web.ViewModels.ShoppingCarts;

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
        public async Task<IActionResult> MyCart()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var cart = await this.shoppingCartService.GetByUserId<ShoppingCartViewModel>(userId);

            return this.View(cart);
        }

        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            await this.shoppingCartService.DeleteItem(userId, id);

            return this.Redirect("/ShoppingCarts/MyCart");
        }
    }
}
