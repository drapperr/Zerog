namespace Zerog.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Zerog.Services.Data;
    using Zerog.Web.ViewModels.Orders;

    public class OrdersController : BaseController
    {
        private readonly IOrdersService orderService;
        private readonly IShoppingCartService shoppingCartService;
        private readonly IAddressService addressService;

        public OrdersController(IOrdersService orderService,
            IShoppingCartService shoppingCartService,
            IAddressService addressService)
        {
            this.orderService = orderService;
            this.shoppingCartService = shoppingCartService;
            this.addressService = addressService;
        }

        [Authorize]
        public async Task<IActionResult> Create(string payment)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var haveAddress = this.addressService.UserHavaAddress(userId);
            if (!haveAddress)
            {
                return this.Redirect("/Addresses/Create");
            }

            await this.orderService.Add(userId, payment);

            await this.shoppingCartService.ClearItems(userId);

            return this.Redirect("/Orders/MyOrders");
        }


        [Authorize]
        public async Task<IActionResult> MyOrders()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var viewModel = this.orderService.GetAllOrdersById(userId);

            return this.View(viewModel);
        }

        [Authorize]
        public async Task<IActionResult> ById(int id)
        {
            var items = this.orderService.GetOrderProductListById(id);

            var userName = this.User.FindFirst(ClaimTypes.Name).Value;
            var email = this.User.FindFirst(ClaimTypes.Email).Value;
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var address = this.addressService.GetByUserId(userId);
            var order = this.orderService.GetOrderById(id);

            var viewModel = new OrderViewModel
            {
                FullName = $"{address.FirstName} {address.LastName}",
                Username = userName,
                Email = email,
                Date = order.Date,
                Phone = address.PhoneNumber,
                Country = $"{address.Country}, {address.ZipCode}",
                City = address.City,
                Address = address.Addreess,
                Items = items,
                PaymentMethod = order.PaymentMethod,
                Status = order.Status,
                Total = order.Total,
            };

            return this.View(viewModel);
        }
    }
}
