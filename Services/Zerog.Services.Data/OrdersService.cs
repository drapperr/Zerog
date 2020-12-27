namespace Zerog.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Zerog.Data.Common.Repositories;
    using Zerog.Data.Models;
    using Zerog.Web.ViewModels.Orders;

    public class OrdersService : IOrdersService
    {
        private readonly IRepository<Order> orderRepository;
        private readonly IRepository<OrderItem> orderItemRepository;
        private readonly IRepository<ShoppingCart> shoppingCartRepository;
        private readonly IRepository<ShoppingCartItem> shoppingCartItemRepository;

        public OrdersService(
            IRepository<Order> orderRepository,
            IRepository<OrderItem> orderItemRepository,
            IRepository<ShoppingCart> shoppingCartRepository,
            IRepository<ShoppingCartItem> shoppingCartItemRepository)
        {
            this.orderRepository = orderRepository;
            this.orderItemRepository = orderItemRepository;
            this.shoppingCartRepository = shoppingCartRepository;
            this.shoppingCartItemRepository = shoppingCartItemRepository;
        }

        public async Task Add(string userId, string paymentMethod)
        {
            var shoppingCart = this.shoppingCartRepository.All().FirstOrDefault(x => x.UserId == userId);

            var items = this.shoppingCartItemRepository.All()
                .Where(x => x.ShoppingCart == shoppingCart)
                .Select(x => new OrderItem
                {
                    Name = x.Product.Name,
                    Price = x.Product.Price,
                    Quantity = x.Quantity,
                    ProductId = x.ProductId,
                }).ToList();

            var order = new Order
            {
                UserId = userId,
                Total = items.Sum(x => x.Price * x.Quantity),
                Items = items,
                PaymentMethod = paymentMethod,
            };

            await this.orderRepository.AddAsync(order);
            await this.orderRepository.SaveChangesAsync();
        }

        public ICollection<OrderInListViewModel> GetAllOrdersById(string userId)
        {
            return this.orderRepository.All()
                 .Where(x => x.UserId == userId)
                 .ToList()
                 .Select(x => new OrderInListViewModel
                 {
                     OrderId = x.Id,
                     Date = x.CreatedOn.ToString("G"),
                     Status = Enum.GetName(typeof(OrderStatus), x.OrderStatus),
                     Total = x.Total,
                 }).ToList();
        }

        public ICollection<ProductInOrderViewModel> GetOrderProductListById(int orderId)
        {
            var items = this.orderItemRepository.All()
                .Where(x => x.OrderId == orderId)
                .Select(x => new ProductInOrderViewModel
                {
                    Id = x.ProductId,
                    Name = x.Name,
                    Price = x.Price,
                    Quantity = x.Quantity,
                    Total = x.Price * x.Quantity,
                }).ToList();

            return items;
        }

        public OrderInListViewModel GetOrderById(int id)
        {
            return this.orderRepository.All()
                 .Where(x => x.Id == id)
                 .ToList()
                 .Select(x => new OrderInListViewModel
                 {
                     OrderId = x.Id,
                     Date = x.CreatedOn.ToString("G"),
                     Status = Enum.GetName(typeof(OrderStatus), x.OrderStatus),
                     Total = x.Total,
                     PaymentMethod = x.PaymentMethod,
                 }).FirstOrDefault();
        }
    }
}
