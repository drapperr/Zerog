namespace Zerog.Services.Data
{
    using System.Threading.Tasks;
    using Zerog.Data.Common.Repositories;
    using Zerog.Data.Models;

    public class OrdersService : IOrdersService
    {
        private readonly IShoppingCartService shoppingCartService;
        private readonly IRepository<Order> orderRepository;

        public OrdersService(
            IShoppingCartService shoppingCartService,
            IRepository<Order> orderRepository)
        {
            this.shoppingCartService = shoppingCartService;
            this.orderRepository = orderRepository;
        }

        public async Task Add(string userId)
        {
           //var shoppingCart = await this.shoppingCartService.GetByUserId<OrderDto>(userId);
        }
    }
}
