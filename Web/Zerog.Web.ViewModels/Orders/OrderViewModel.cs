namespace Zerog.Web.ViewModels.Orders
{
    using System.Collections.Generic;

    public class OrderViewModel
    {
        public OrderViewModel()
        {
            this.Items = new HashSet<ProductInOrderViewModel>();
        }

        public string FullName { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public string Date { get; set; }

        public string PaymentMethod { get; set; }

        public string Status { get; set; }

        public ICollection<ProductInOrderViewModel> Items { get; set; }

        public decimal Total { get; set; }
    }
}
