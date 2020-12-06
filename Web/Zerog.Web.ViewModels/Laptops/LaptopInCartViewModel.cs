namespace Zerog.Web.ViewModels.Laptops
{
    public class LaptopInCartViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int? Discount { get; set; }

        public decimal NewPrice => this.Discount == null ? this.Price : this.Price - (this.Price * ((decimal)this.Discount / 100));

        public int Quantity { get; set; }
    }
}
