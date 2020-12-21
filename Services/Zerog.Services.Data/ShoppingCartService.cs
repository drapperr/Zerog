namespace Zerog.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using Zerog.Data.Common.Repositories;
    using Zerog.Data.Models;
    using Zerog.Services.Mapping;

    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IRepository<ShoppingCart> shoppingCardRepository;
        private readonly IRepository<ShoppingCartItem> productCoutnRepository;

        public ShoppingCartService(
            IRepository<ShoppingCart> shoppingCardRepository,
            IRepository<ShoppingCartItem> productCoutnRepository)
        {
            this.shoppingCardRepository = shoppingCardRepository;
            this.productCoutnRepository = productCoutnRepository;
        }

        public async Task AddProductAsync(string userId, int productId)
        {
            var shoppingCart = this.shoppingCardRepository.All().FirstOrDefault(x => x.UserId == userId);

            if (shoppingCart is null)
            {
                var newShoppingCart = new ShoppingCart
                {
                    UserId = userId,
                };

                await this.shoppingCardRepository.AddAsync(newShoppingCart);
                await this.shoppingCardRepository.SaveChangesAsync();

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
            var shoppingCart = this.shoppingCardRepository.All().FirstOrDefault(x => x.UserId == id);

            if (shoppingCart is null)
            {
                var newShoppingCart = new ShoppingCart
                {
                    UserId = id,
                };

                await this.shoppingCardRepository.AddAsync(newShoppingCart);
                await this.shoppingCardRepository.SaveChangesAsync();

                shoppingCart = newShoppingCart;
            }

            var viewModel = this.shoppingCardRepository.All()
                .Where(x => x.UserId == id).To<T>().FirstOrDefault();

            return viewModel;
        }

        public async Task DeleteItem(string userId, int itemId)
        {
            var shoppingCart = this.shoppingCardRepository.All().FirstOrDefault(x => x.UserId == userId);

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
    }
}
