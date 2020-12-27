namespace Zerog.Web.ViewModels.Orders
{
    public class OrderInListViewModel
    {
        public int OrderId { get; set; }

        public string Date { get; set; }

        public string Status { get; set; }

        public string PaymentMethod { get; set; }

        public decimal Total { get; set; }
    }
}
