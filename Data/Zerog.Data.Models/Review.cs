namespace Zerog.Data.Models
{
    using Zerog.Data.Common.Models;
    using Zerog.Data.Models.ProductModels;

    public class Review : BaseModel<int>
    {
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public string Content { get; set; }

        public int Stars { get; set; }
    }
}
