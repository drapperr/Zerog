namespace Zerog.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Zerog.Data.Common.Models;
    using Zerog.Data.Models.ProductModels;

    public class Review : BaseModel<int>
    {
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        [Required]
        [MaxLength(200)]
        public string Content { get; set; }

        [Range(1, 5)]
        public int Stars { get; set; }
    }
}
