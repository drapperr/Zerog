namespace Zerog.Web.ViewModels
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using Zerog.Data.Common.Models;
    using Zerog.Services.Mapping;

    public class MotherboardViewModel : IMapFrom<Motherboard>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public string ManufacturerName { get; set; }

        public decimal Price { get; set; }

        public ICollection<string> Images { get; set; }

        public string SocketName { get; set; }

        public string ChipsetName { get; set; }

        public ICollection<string> SupportedProcessors { get; set; }

        public string MemoryTypeName { get; set; }

        public int MemorySpeed { get; set; }

        public int MemorySlots { get; set; }

        public string SoundCardName { get; set; }

        public string LanCardName { get; set; }

        public ICollection<NameCountDtoModel> Interfaces { get; set; }

        public ICollection<NameCountDtoModel> Ports { get; set; }

        public string FormFactorName { get; set; }

        public string Demensions { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Motherboard, MotherboardViewModel>()
                .ForMember(
                    m => m.SupportedProcessors,
                    opt => opt.MapFrom(x => x.SupportedProcessors
                    .Select(x => x.SupportedProcessor.Name).ToList()))
                .ForMember(
                    m => m.Interfaces,
                    opt => opt.MapFrom(x => x.Interfaces
                    .Select(i => new NameCountDtoModel
                    {
                        Name = i.Interface.Name,
                        Count = i.Count,
                    }).ToList()))
                .ForMember(
                    m => m.Ports,
                    opt => opt.MapFrom(x => x.Ports
                    .Select(i => new NameCountDtoModel
                    {
                        Name = i.Port.Name,
                        Count = i.Count,
                    }).ToList()))
                .ForMember(
                    m => m.Images,
                    opt => opt.MapFrom(x => x.Images
                    .Select(i => i.Url).ToList()));
        }
    }
}
