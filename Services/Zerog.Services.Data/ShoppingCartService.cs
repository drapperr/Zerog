namespace Zerog.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using Zerog.Data.Common.Repositories;
    using Zerog.Data.Models;
    using Zerog.Services.Mapping;

    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IRepository<ShoppingCart> shoppingCartRepository;
        private readonly IRepository<ShoppingCartItem> productCoutnRepository;

        public ShoppingCartService(
            IRepository<ShoppingCart> shoppingCartRepository,
            IRepository<ShoppingCartItem> productCountRepository)
        {
            this.shoppingCartRepository = shoppingCartRepository;
            this.productCoutnRepository = productCountRepository;
        }

        public async Task AddProductAsync(string userId, int productId)
        {
            var shoppingCart = this.shoppingCartRepository.All().FirstOrDefault(x => x.UserId == userId);

            if (shoppingCart is null)
            {
                var newShoppingCart = new ShoppingCart
                {
                    UserId = userId,
                };

                await this.shoppingCartRepository.AddAsync(newShoppingCart);
                await this.shoppingCartRepository.SaveChangesAsync();

                shoppingCart = newShoppingCart;
            }

            var item = this.productCoutnRepository.All()
                .FirstOrDefault(x => x.ProductId == productId && x.ShoppingCart == shoppingCart);

            if (item is null)
            {
                item = new ShoppingCartItem
                {
                    ProductId = productId,
                    ShoppingCartId = shoppingCart.Id,
                    Quantity = 1,
                };

                await this.productCoutnRepository.AddAsync(item);
            }
            else
            {
                item.Quantity++;
            }

            await this.productCoutnRepository.SaveChangesAsync();
        }

        public async Task<T> GetByUserId<T>(string id)
        {
            var shoppingCart = this.shoppingCartRepository.All().FirstOrDefault(x => x.UserId == id);

            if (shoppingCart is null)
            {
                var newShoppingCart = new ShoppingCart
                {
                    UserId = id,
                };

                await this.shoppingCartRepository.AddAsync(newShoppingCart);
                await this.shoppingCartRepository.SaveChangesAsync();

                shoppingCart = newShoppingCart;
            }

            var viewModel = this.shoppingCartRepository.All()
                .Where(x => x.UserId == id).To<T>().FirstOrDefault();

            return viewModel;
        }

        public async Task DeleteItem(string userId, int itemId)
        {
            var shoppingCart = this.shoppingCartRepository.All().FirstOrDefault(x => x.UserId == userId);

            var item = this.productCoutnRepository.All()
                .FirstOrDefault(x => x.ShoppingCart == shoppingCart && x.Id == itemId);

            if (item.Quantity == 1)
            {
                this.productCoutnRepository.Delete(item);
            }
            else
            {
                item.Quantity -= 1;
            }

            await this.productCoutnRepository.SaveChangesAsync();
        }

        public async Task ClearItems(string userId)
        {
            var shoppingCart = this.shoppingCartRepository.All().FirstOrDefault(x => x.UserId == userId);

            var items = this.productCoutnRepository.All()
               .Where(x => x.ShoppingCart == shoppingCart);

            foreach (var item in items)
            {
                this.productCoutnRepository.Delete(item);
            }

            await this.productCoutnRepository.SaveChangesAsync();
        }
    }
}
