namespace Zerog.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Zerog.Web.ViewModels.Reviews;

    public interface IReviewService
    {
        Task Add(CreateReviewInputModel input);

        Task Remove(string userId, int productId);

        ICollection<T> GetAll<T>(int productId);

        ICollection<T> LastThree<T>(int productId);

        Dictionary<int, int> GetStarsCount(int productId);

        double GetAverageStars(int productId);
    }
}
