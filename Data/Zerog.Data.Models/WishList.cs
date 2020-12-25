namespace Zerog.Data.Models
{
    using Zerog.Data.Common.Models;
    using Zerog.Data.Models.ProductModels;

    public class WishList : BaseModel<int>
    {
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}
