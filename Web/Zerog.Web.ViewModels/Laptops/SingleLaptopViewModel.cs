namespace Zerog.Web.ViewModels.Laptops
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using Zerog.Data.Models.LaptopModels;
    using Zerog.Services.Mapping;

    public class SingleLaptopViewModel : IMapFrom<Laptop>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int? Discount { get; set; }

        public decimal NewPrice => this.Discount == null ? this.Price : this.Price - (this.Price * ((decimal)this.Discount / 100));

        public string Category => "Laptop";

        public bool IsNew { get; set; }

        public string ManufacturerName { get; set; }

        public ICollection<string> Images { get; set; }

        public string PurposeName { get; set; }

        public string ProcessorName { get; set; }

        public string VideoCardName { get; set; }

        public string MemoryName { get; set; }

        public int MemorySlots { get; set; }

        public string HDDName { get; set; }

        public string SSDName { get; set; }

        public string DisplayName { get; set; }

        public string CameraName { get; set; }

        public string AudioName { get; set; }

        public bool OpticalDevice { get; set; }

        public string WiFiName { get; set; }

        public string LanName { get; set; }

        public ICollection<CreatePortInputViewModel> Ports { get; set; }

        public ICollection<string> KeyboardDetails { get; set; }

        public ICollection<string> Extras { get; set; }

        public string OperatingSystemName { get; set; }

        public string BatteryName { get; set; }

        public double Weight { get; set; }

        public string Demensions { get; set; }

        public string ColorName { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Laptop, SingleLaptopViewModel>()
                .ForMember(x => x.Images, opt =>
                    opt.MapFrom(x => x.Images.Select(x => x.Url)))
                .ForMember(x => x.Ports, opt =>
                    opt.MapFrom(x => x.Ports.Select(p => new CreatePortInputViewModel { Name = p.Port.Name, Count = p.Count })))
                .ForMember(x => x.KeyboardDetails, opt =>
                    opt.MapFrom(x => x.KeyboardDetails.Select(x => x.Name)))
                .ForMember(x => x.Extras, opt =>
                    opt.MapFrom(x => x.Extras.Select(x => x.Name)))
                .ForMember(x => x.IsNew, opt =>
                    opt.MapFrom(x => (DateTime.UtcNow - x.CreatedOn).Days < 30));
        }
    }
}
