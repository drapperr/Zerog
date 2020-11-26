﻿namespace Zerog.Web.ViewModels.Laptops
{
    using System;
    using System.Linq;

    using AutoMapper;
    using Zerog.Data.Models.LaptopModels;
    using Zerog.Services.Mapping;

    public class LaptopInListViewModel : IMapFrom<Laptop>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int? Discount { get; set; }

        public decimal NewPrice => this.Discount == null ? this.Price : this.Price - (this.Price * ((decimal)this.Discount / 100));

        public string CategoryName { get; set; }

        public bool IsNew { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Laptop, LaptopInListViewModel>()
                .ForMember(x => x.ImageUrl, opt =>
                    opt.MapFrom(x => x.Images.FirstOrDefault().Url))
                .ForMember(x => x.IsNew, opt =>
                    opt.MapFrom(x => (DateTime.UtcNow - x.CreatedOn).Days < 30));
        }
    }
}
