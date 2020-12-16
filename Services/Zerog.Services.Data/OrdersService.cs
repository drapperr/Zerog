namespace Zerog.Services.Data
{
    using System;
    using System.Threading.Tasks;

    public class OrdersService : IOrdersService
    {
        private readonly IShoppingCartService shoppingCartService;

        public OrdersService(IShoppingCartService shoppingCartService)
        {
            this.shoppingCartService = shoppingCartService;
        }

        public Task Add(string userId, int cardId)
        {
            throw new NotImplementedException();
        }
    }
}
