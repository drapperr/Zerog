namespace Zerog.Web.ViewModels.Reviews
{
    using System.Collections.Generic;

    public class AllReviewsViewModel
    {
        public int ProductId { get; set; }

        public string UserId { get; set; }

        public ICollection<SingleReviewViewModel> Reviews { get; set; }

        public Dictionary<int, int> Stars { get; set; }

        public double AverageStars { get; set; }
    }
}
