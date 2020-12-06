﻿namespace Zerog.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Zerog.Data.Common.Repositories;
    using Zerog.Data.Models;
    using Zerog.Services.Mapping;
    using Zerog.Web.ViewModels.Laptops;

    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IDeletableEntityRepository<Cart> cartRepository;
        private readonly IDeletableEntityRepository<CartItem> cartItemRepository;

        public ShoppingCartService(
            IDeletableEntityRepository<Cart> shoppingCardRepository,
            IDeletableEntityRepository<CartItem> productCoutnRepository)
        {
            this.cartRepository = shoppingCardRepository;
            this.cartItemRepository = productCoutnRepository;
        }

        public async Task AddProductAsync(string userId, int productId)
        {
            var cart = this.cartRepository.All().FirstOrDefault(x => x.UserId == userId);

            if (cart is null)
            {
                var newShoppingCart = new Cart
                {
                    UserId = userId,
                };

                await this.cartRepository.AddAsync(newShoppingCart);
                await this.cartRepository.SaveChangesAsync();

                cart = newShoppingCart;
            }

            var item = this.cartItemRepository.All()
                .FirstOrDefault(x => x.LaptopId == productId && x.Cart == cart);

            if (item is null)
            {
                item = new CartItem
                {
                    LaptopId = productId,
                    CartId = cart.Id,
                    Quantity = 1,
                };

                await this.cartItemRepository.AddAsync(item);
            }
            else
            {
                item.Quantity++;
            }

            await this.cartItemRepository.SaveChangesAsync();
        }

        public ShoppingCartViewModel GetByUserId(string id)
        {
            return this.cartRepository.All()
                .Where(x => x.UserId == id)
                .Select(x => new ShoppingCartViewModel
                {
                    Items = x.Items
                    .Select(y => new LaptopInCartViewModel
                    {
                        Id = y.Laptop.Id,
                        Name = y.Laptop.Name,
                        Price = y.Laptop.Price,
                        Discount = y.Laptop.Discount,
                        Quantity = y.Quantity,
                    }).ToList(),
                    Total = x.Items.Sum(x => x.Laptop.Price * x.Quantity),
                }).FirstOrDefault();
        }
    }
}
