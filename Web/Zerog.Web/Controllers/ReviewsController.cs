namespace Zerog.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Zerog.Services.Data;
    using Zerog.Web.ViewModels.Reviews;

    public class ReviewsController : BaseController
    {
        private readonly IReviewService reviewService;

        public ReviewsController(IReviewService reviewService)
        {
            this.reviewService = reviewService;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(CreateReviewInputModel input ,int id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect($"/Reviews/All/{id}");
            }

            input.UserId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            await this.reviewService.Add(input);

            return this.Redirect($"/Reviews/All/{input.ProductId}");
        }

        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            await this.reviewService.Remove(userId, id);

            return this.Redirect($"/Reviews/All/{id}");
        }

        [Authorize]
        public IActionResult All(int id)
        {
            var viewModel = new AllReviewsViewModel
            {
                ProductId = id,
                UserId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value,
                Reviews = this.reviewService.GetAll<SingleReviewViewModel>(id),
                AverageStars = this.reviewService.GetAverageStars(id),
                Stars = this.reviewService.GetStarsCount(id),
            };

            return this.View(viewModel);
        }
    }
}
