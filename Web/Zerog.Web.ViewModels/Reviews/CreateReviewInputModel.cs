namespace Zerog.Web.ViewModels.Reviews
{
    public class CreateReviewInputModel
    {
        public string UserId { get; set; }

        public int ProductId { get; set; }

        public string Content { get; set; }

        public int Stars { get; set; }
    }
}
