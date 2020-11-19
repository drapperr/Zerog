namespace Zerog.Data.Common.Models
{
    using System.ComponentModel.DataAnnotations;

    public class MotherboardImage : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(200)]
        public string Url { get; set; }
    }
}
