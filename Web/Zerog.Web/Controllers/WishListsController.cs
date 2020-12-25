using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Zerog.Services.Data;
using Zerog.Web.ViewModels.WishLists;

namespace Zerog.Web.Controllers
{
    public class WishListsController : BaseController
    {
        private readonly IWishListService wishListService;

        public WishListsController(IWishListService wishListService)
        {
            this.wishListService = wishListService;
        }

        [Authorize]
        public async Task<IActionResult> Add(int id)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            await this.wishListService.AddProductAsync(userId, id);

            return this.Redirect("/WishLists/All");
        }

        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            await this.wishListService.RemoveProduct(userId, id);

            return this.Redirect("/WishLists/All");
        }

        [Authorize]
        public IActionResult All()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            List<WishListViewModel> view = this.wishListService.GetAllProductsAsync<WishListViewModel>(userId).ToList();

            return this.View(view);
        }
    }
}
