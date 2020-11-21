namespace Zerog.Data.Models.LaptopModels
{
    using System.ComponentModel.DataAnnotations;

    using Zerog.Data.Common.Models;

    public class Image : BaseModel<int>
    {
        [Required]
        [MaxLength(100)]
        public string Url { get; set; }

        public int LaptopId { get; set; }

        public virtual Laptop Laptop { get; set; }
    }
}
