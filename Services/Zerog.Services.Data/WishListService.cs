namespace Zerog.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Zerog.Data.Common.Repositories;
    using Zerog.Data.Models;
    using Zerog.Services.Mapping;

    public class WishListService : IWishListService
    {
        private readonly IRepository<WishList> wishListRepository;

        public WishListService(IRepository<WishList> wishListRepository)
        {
            this.wishListRepository = wishListRepository;
        }

        public async Task AddProductAsync(string userId, int productId)
        {
            var wishList = new WishList
            {
                UserId = userId,
                ProductId = productId,
            };

            await this.wishListRepository.AddAsync(wishList);
            await this.wishListRepository.SaveChangesAsync();
        }

        public ICollection<T> GetAllProductsAsync<T>(string userId)
        {
            return this.wishListRepository.All()
                .Where(x => x.UserId == userId)
                .Select(x => x.Product)
                .To<T>()
                .ToList();
        }

        public int GetAllProductsCount(string userId)
        {
            var count = this.wishListRepository.All().Count(x => x.UserId == userId);

            return count;
        }

        public async Task RemoveProduct(string userId, int productId)
        {
            var product = this.wishListRepository.All()
                .FirstOrDefault(x => x.UserId == userId && x.ProductId == productId);

            this.wishListRepository.Delete(product);
            await this.wishListRepository.SaveChangesAsync();
        }
    }
}
