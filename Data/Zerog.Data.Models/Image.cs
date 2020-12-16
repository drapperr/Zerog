namespace Zerog.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Zerog.Data.Common.Models;
    using Zerog.Data.Models.ProductModels;

    public class Image : BaseModel<int>
    {
        [Required]
        [MaxLength(100)]
        public string Url { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
