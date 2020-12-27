namespace Zerog.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using System.Security.Claims;
    using System.Threading.Tasks;

    using Zerog.Services.Data;
    using Zerog.Web.ViewModels.Addresses;

    public class AddressesController : BaseController
    {
        private readonly IAddressService addressService;

        public AddressesController(IAddressService addressService)
        {
            this.addressService = addressService;
        }

        [Authorize]
        public async Task<IActionResult> Create()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(AddressInputModel input)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            await this.addressService.Add(input, userId);

            return this.Redirect("/Addresses/MyAddress");
        }

        [Authorize]
        public async Task<IActionResult> MyAddress()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var haveAddress = this.addressService.UserHavaAddress(userId);
            if (!haveAddress)
            {
                return this.Redirect("/Addresses/Create");
            }

            var addressViewModel = this.addressService.GetByUserId(userId);

            return this.View(addressViewModel);
        }
    }
}
