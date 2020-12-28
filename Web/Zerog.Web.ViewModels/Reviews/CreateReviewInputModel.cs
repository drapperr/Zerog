using System.ComponentModel.DataAnnotations;

namespace Zerog.Web.ViewModels.Reviews
{
    public class CreateReviewInputModel
    {
        public string UserId { get; set; }

        public int ProductId { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(200)]
        public string Content { get; set; }

        [Range(1,5)]
        public int Stars { get; set; }
    }
}
