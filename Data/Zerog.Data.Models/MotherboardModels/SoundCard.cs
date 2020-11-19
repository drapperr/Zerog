namespace Zerog.Data.Common.Models
{
    using System.ComponentModel.DataAnnotations;

    public class SoundCard : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
