namespace Zerog.Data.Common.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Port : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
