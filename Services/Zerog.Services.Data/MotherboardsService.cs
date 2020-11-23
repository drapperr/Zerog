namespace Zerog.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using Zerog.Data.Common.Models;
    using Zerog.Data.Common.Repositories;
    using Zerog.Services.Mapping;
    using Zerog.Web.ViewModels;

    public class MotherboardsService : IMotherboardsService
    {
        private readonly IDeletableEntityRepository<Motherboard> motherboardRepository;
        private readonly IDeletableEntityRepository<MotherboardManufacturer> manufacturerRepository;
        private readonly IDeletableEntityRepository<Sockets> socketReposiotory;
        private readonly IDeletableEntityRepository<Chipset> chipsetRepository;
        private readonly IDeletableEntityRepository<SupportedProcessor> suppurtedProcesorRepository;
        private readonly IDeletableEntityRepository<MemoryType> memoryTypeRepository;
        private readonly IDeletableEntityRepository<SoundCard> soundCardRepository;
        private readonly IDeletableEntityRepository<LanCard> lanCardRepository;
        private readonly IDeletableEntityRepository<Interface> interfaceRepository;
        private readonly IDeletableEntityRepository<MPort> portRepository;
        private readonly IDeletableEntityRepository<FormFactor> formFactorRepository;

        public MotherboardsService(
            IDeletableEntityRepository<Motherboard> motherboardRepository,
            IDeletableEntityRepository<MotherboardManufacturer> manufacturerRepository,
            IDeletableEntityRepository<Sockets> socketReposiotory,
            IDeletableEntityRepository<Chipset> chipsetRepository,
            IDeletableEntityRepository<SupportedProcessor> suppurtedProcesorRepository,
            IDeletableEntityRepository<MemoryType> memoryTypeRepository,
            IDeletableEntityRepository<SoundCard> soundCardRepository,
            IDeletableEntityRepository<LanCard> lanCardRepository,
            IDeletableEntityRepository<Interface> interfaceRepository,
            IDeletableEntityRepository<MPort> portRepository,
            IDeletableEntityRepository<FormFactor> formFactorRepository)
        {
            this.motherboardRepository = motherboardRepository;
            this.manufacturerRepository = manufacturerRepository;
            this.socketReposiotory = socketReposiotory;
            this.chipsetRepository = chipsetRepository;
            this.suppurtedProcesorRepository = suppurtedProcesorRepository;
            this.memoryTypeRepository = memoryTypeRepository;
            this.soundCardRepository = soundCardRepository;
            this.lanCardRepository = lanCardRepository;
            this.interfaceRepository = interfaceRepository;
            this.portRepository = portRepository;
            this.formFactorRepository = formFactorRepository;
        }

        public void Add(MotherboardViewModel input)
        {
            // MotherboardManufacturer manufacturer = this.GetOrCreateManufacturer(input.Manufacturer);
            // Sockets socket = this.GetOrCreateSocket(input.Socket);
            // Chipset chipset = this.GetOrCreateChipset(input.Chipset);
            // List<MotherboardSupportedProcessor> supportedProcessors = this.GetOrCreateSupportedProcressors(input.SupportedProcessors);
            // MemoryType memoryType = this.GetOrCreateMemoryType(input.MemoryType);
            // SoundCard soundCard = this.GetOrCreateSoundCard(input.SoundCard);
            // LanCard lanCard = this.GetOrCreateLanCard(input.LanCard);
            // List<MotherboardInterface> interfaces = this.GetOrCreateInterfaces(input.Interfaces);
            // List<MotherboardPorts> ports = this.GetOrCreatePorts(input.Ports);
            // FormFactor formFactor = this.GetOrCreateFormFactor(input.FormFactor);

            // var motherboard = new Motherboard
            // {
            //    Name = input.Name,
            //    Manufacturer = manufacturer,
            //    Price = input.Price,
            //    Images = input.Images.Select(i => new MotherboardImage { Url = i }).ToList(),
            //    Socket = socket,
            //    Chipset = chipset,
            //    SupportedProcessors = supportedProcessors,
            //    MemoryType = memoryType,
            //    MemorySpeed = input.MemorySpeed,
            //    MemorySlots = input.MemorySlots,
            //    SoundCard = soundCard,
            //    LanCard = lanCard,
            //    Interfaces = interfaces,
            //    Ports = ports,
            //    FormFactor = formFactor,
            //    Demensions = input.Demensions,
            // };

            // this.motherboardRepository.AddAsync(motherboard);
            // this.motherboardRepository.SaveChangesAsync();
        }

        public IEnumerable<MotherboardViewModel> GetAll()
        {
            return this.motherboardRepository.AllAsNoTracking().Take(12)
                .To<MotherboardViewModel>()
                 .ToList();
        }

        private FormFactor GetOrCreateFormFactor(string formFactorName)
        {
            var formFactor = this.formFactorRepository.AllAsNoTracking().FirstOrDefault(x => x.Name == formFactorName);

            if (formFactor is null)
            {
                formFactor = new FormFactor { Name = formFactorName };
            }

            return formFactor;
        }

        private List<MotherboardPort> GetOrCreatePorts(ICollection<NameCountDtoModel> inputPorts)
        {
            var ports = new List<MotherboardPort>();

            foreach (var portModel in inputPorts)
            {
                var port = this.portRepository.AllAsNoTracking().FirstOrDefault(x => x.Name == portModel.Name);

                if (port is null)
                {
                    port = new MPort { Name = portModel.Name };
                }

                ports.Add(new MotherboardPort { Port = port, Count = portModel.Count });
            }

            return ports;
        }

        private List<MotherboardInterface> GetOrCreateInterfaces(ICollection<NameCountDtoModel> inputInerfaces)
        {
            var interfaces = new List<MotherboardInterface>();

            foreach (var interfaceModel in inputInerfaces)
            {
                var @interface = this.interfaceRepository.AllAsNoTracking().FirstOrDefault(x => x.Name == interfaceModel.Name);
                if (@interface is null)
                {
                    @interface = new Interface { Name = interfaceModel.Name };
                }

                interfaces.Add(new MotherboardInterface { Interface = @interface, Count = interfaceModel.Count });
            }

            return interfaces;
        }

        private LanCard GetOrCreateLanCard(string lanCardName)
        {
            var lanCard = this.lanCardRepository.AllAsNoTracking().FirstOrDefault(x => x.Name == lanCardName);

            if (lanCard is null)
            {
                lanCard = new LanCard { Name = lanCardName };
            }

            return lanCard;
        }

        private SoundCard GetOrCreateSoundCard(string soundCardName)
        {
            var soundCard = this.soundCardRepository.AllAsNoTracking().FirstOrDefault(x => x.Name == soundCardName);

            if (soundCard is null)
            {
                soundCard = new SoundCard { Name = soundCardName };
            }

            return soundCard;
        }

        private MemoryType GetOrCreateMemoryType(string memoryTypeName)
        {
            var memoryType = this.memoryTypeRepository.AllAsNoTracking().FirstOrDefault(x => x.Name == memoryTypeName);

            if (memoryType is null)
            {
                memoryType = new MemoryType { Name = memoryTypeName };
            }

            return memoryType;
        }

        private List<MotherboardSupportedProcessor> GetOrCreateSupportedProcressors(ICollection<string> processors)
        {
            var supportedProcessors = new List<MotherboardSupportedProcessor>();

            foreach (var processorName in processors)
            {
                var supportedProcessor = this.suppurtedProcesorRepository.AllAsNoTracking().FirstOrDefault(x => x.Name == processorName);

                if (supportedProcessor is null)
                {
                    supportedProcessor = new SupportedProcessor { Name = processorName };
                }

                supportedProcessors.Add(new MotherboardSupportedProcessor { SupportedProcessor = supportedProcessor });
            }

            return supportedProcessors;
        }

        private Chipset GetOrCreateChipset(string chipsetName)
        {
            var chipset = this.chipsetRepository.AllAsNoTracking().FirstOrDefault(x => x.Name == chipsetName);

            if (chipset is null)
            {
                chipset = new Chipset { Name = chipsetName };
            }

            return chipset;
        }

        private Sockets GetOrCreateSocket(string socketName)
        {
            var socket = this.socketReposiotory.AllAsNoTracking().FirstOrDefault(x => x.Name == socketName);

            if (socket is null)
            {
                socket = new Sockets { Name = socketName };
            }

            return socket;
        }

        private MotherboardManufacturer GetOrCreateManufacturer(string manufacturerName)
        {
            var manufacturer = this.manufacturerRepository.All().FirstOrDefault(p => p.Name == manufacturerName);

            if (manufacturer is null)
            {
                manufacturer = new MotherboardManufacturer { Name = manufacturerName };
            }

            return manufacturer;
        }
    }
}
