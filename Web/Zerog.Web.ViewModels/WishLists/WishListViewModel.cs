namespace Zerog.Web.ViewModels.WishLists
{
    using AutoMapper;
    using System.Linq;
    using Zerog.Data.Models.ProductModels;
    using Zerog.Services.Mapping;

    public class WishListViewModel : IMapFrom<Product>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal NewPrice { get; set; }

        public string CategoryName { get; set; }

        public string ImageUrl { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Product, WishListViewModel>()
                .ForMember(x => x.ImageUrl, opt =>
                    opt.MapFrom(x => x.Images.FirstOrDefault().Url));
        }
    }
}
