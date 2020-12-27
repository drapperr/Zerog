namespace Zerog.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Zerog.Web.ViewModels.Orders;

    public interface IOrdersService
    {
        Task Add(string userId, string paymentMethod);

        ICollection<OrderInListViewModel> GetAllOrdersById(string userId);

        OrderInListViewModel GetOrderById(int id);

        ICollection<ProductInOrderViewModel> GetOrderProductListById(int orderId);
    }
}
