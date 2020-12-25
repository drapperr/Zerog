namespace Zerog.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Zerog.Data.Common.Repositories;
    using Zerog.Data.Models;
    using Zerog.Services.Mapping;
    using Zerog.Web.ViewModels.Reviews;

    public class ReviewService : IReviewService
    {
        private readonly IRepository<Review> reviewRepository;

        public ReviewService(IRepository<Review> reviewRepository)
        {
            this.reviewRepository = reviewRepository;
        }

        public async Task Add(CreateReviewInputModel input)
        {
            var review = new Review
            {
                ProductId = input.ProductId,
                UserId = input.UserId,
                Content = input.Content,
                Stars = input.Stars,
            };

            await this.reviewRepository.AddAsync(review);
            await this.reviewRepository.SaveChangesAsync();
        }

        public ICollection<T> GetAll<T>(int productId)
        {
            return this.reviewRepository.All()
                .Where(x => x.ProductId == productId)
                .OrderByDescending(x => x.CreatedOn)
                .To<T>()
                .ToList();
        }

        public double GetAverageStars(int productId)
        {
            var starsList = this.reviewRepository.All()
             .Where(x => x.ProductId == productId)
             .Select(x => x.Stars)
             .ToList();

            if (starsList.Count == 0)
            {
                return 0;
            }

            return starsList.Average();
        }

        public Dictionary<int, int> GetStarsCount(int productId)
        {
            var starsList = this.reviewRepository.All()
              .Where(x => x.ProductId == productId)
              .Select(x => x.Stars)
              .ToList();

            var starsCount = new Dictionary<int, int>()
            {
                { 1, 0 },
                { 2, 0 },
                { 3, 0 },
                { 4, 0 },
                { 5, 0 },
            };

            foreach (var item in starsList)
            {
                starsCount[item]++;
            }

            return starsCount;
        }

        public ICollection<T> LastThree<T>(int productId)
        {
            return this.reviewRepository.All()
              .Where(x => x.ProductId == productId)
              .OrderByDescending(x => x.CreatedOn)
              .Take(3)
              .To<T>()
              .ToList();
        }

        public async Task Remove(string userId, int productId)
        {
            var review = this.reviewRepository.All()
                .Where(x => x.UserId == userId && x.ProductId == productId)
                .FirstOrDefault();

            this.reviewRepository.Delete(review);
            await this.reviewRepository.SaveChangesAsync();
        }
    }
}
