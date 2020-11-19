namespace Zerog.Data.Common.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Interface : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
