namespace Zerog.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Zerog.Data.Common.Repositories;
    using Zerog.Data.Models.LaptopModels;
    using Zerog.Services.Mapping;
    using Zerog.Web.ViewModels.Laptops;

    public class LaptopService : ILaptopService
    {
        private readonly IDeletableEntityRepository<Laptop> laptopRepository;
        private readonly IDeletableEntityRepository<Manufacturer> manufacturerRepository;
        private readonly IDeletableEntityRepository<Purpose> purposeRepository;
        private readonly IDeletableEntityRepository<Processor> processorRepository;
        private readonly IDeletableEntityRepository<VideoCard> videoCardRepository;
        private readonly IDeletableEntityRepository<Memory> memoryRepository;
        private readonly IDeletableEntityRepository<HDD> hddRepository;
        private readonly IDeletableEntityRepository<SSD> ssdRepository;
        private readonly IDeletableEntityRepository<Display> displayRepository;
        private readonly IDeletableEntityRepository<Camera> cameraRepository;
        private readonly IDeletableEntityRepository<Audio> audioRepository;
        private readonly IDeletableEntityRepository<WiFi> wifiRepository;
        private readonly IDeletableEntityRepository<Lan> lanRepository;
        private readonly IDeletableEntityRepository<Port> portRepository;
        private readonly IDeletableEntityRepository<KeyboardDetail> keyboardRepository;
        private readonly IDeletableEntityRepository<Extra> extraRepository;
        private readonly IDeletableEntityRepository<OpSystem> operatinSystemRepository;
        private readonly IDeletableEntityRepository<Battery> batteryRepository;
        private readonly IDeletableEntityRepository<Color> colorRepository;

        public LaptopService(
            IDeletableEntityRepository<Laptop> laptopRepository,
            IDeletableEntityRepository<Manufacturer> manufacturerRepository,
            IDeletableEntityRepository<Purpose> purposeRepository,
            IDeletableEntityRepository<Processor> processorRepository,
            IDeletableEntityRepository<VideoCard> videoCardRepository,
            IDeletableEntityRepository<Memory> memoryRepository,
            IDeletableEntityRepository<HDD> hddRepository,
            IDeletableEntityRepository<SSD> ssdRepository,
            IDeletableEntityRepository<Display> displayRepository,
            IDeletableEntityRepository<Camera> cameraRepository,
            IDeletableEntityRepository<Audio> audioRepository,
            IDeletableEntityRepository<WiFi> wifiRepository,
            IDeletableEntityRepository<Lan> lanRepository,
            IDeletableEntityRepository<Port> portRepository,
            IDeletableEntityRepository<KeyboardDetail> keyboardRepository,
            IDeletableEntityRepository<Extra> extraRepository,
            IDeletableEntityRepository<OpSystem> operatinSystemRepository,
            IDeletableEntityRepository<Battery> batteryRepository,
            IDeletableEntityRepository<Color> colorRepository)
        {
            this.laptopRepository = laptopRepository;
            this.manufacturerRepository = manufacturerRepository;
            this.purposeRepository = purposeRepository;
            this.processorRepository = processorRepository;
            this.videoCardRepository = videoCardRepository;
            this.memoryRepository = memoryRepository;
            this.hddRepository = hddRepository;
            this.ssdRepository = ssdRepository;
            this.displayRepository = displayRepository;
            this.cameraRepository = cameraRepository;
            this.audioRepository = audioRepository;
            this.wifiRepository = wifiRepository;
            this.lanRepository = lanRepository;
            this.portRepository = portRepository;
            this.keyboardRepository = keyboardRepository;
            this.extraRepository = extraRepository;
            this.operatinSystemRepository = operatinSystemRepository;
            this.batteryRepository = batteryRepository;
            this.colorRepository = colorRepository;
        }

        public async Task CreateAsync(CreateLaptopInputModel input)
        {
            Manufacturer manufacturer = this.GetOrCreateManufacturer(input.Manufacturer);
            Purpose purpose = this.GetOrCreatePurpose(input.Purpose);
            Processor processor = this.GetOrCreateProcessor(input.Processor);
            VideoCard videCard = this.GetOrCreateVideoCard(input.VideoCard);
            Memory memory = this.GetOrCreateMemory(input.Memory);
            HDD hdd = this.GetOrCreateHDD(input.HDD);
            SSD ssd = this.GetOrCreateSSD(input.SSD);
            Display display = this.GetOrCreateDisplay(input.Display);
            Camera camera = this.GetOrCreateCamera(input.Camera);
            Audio audio = this.GetOrCreateAudio(input.Audio);
            WiFi wifi = this.GetOrCreateWiFi(input.WiFi);
            Lan lan = this.GetOrCreateLan(input.Lan);
            OpSystem operatingSystem = this.GetOrCreateOperatingSystem(input.OperatingSystem);
            Battery battery = this.GetOrCreateBattery(input.Battery);
            Color color = this.GetOrCreateColor(input.Color);

            var laptopPorts = new List<LaptopPort>();
            foreach (var portModel in input.Ports)
            {
                Port port = this.GetOrCreatePort(portModel.Name);
                laptopPorts.Add(new LaptopPort { Port = port, Count = portModel.Count });
            }

            var keyboardDetails = new List<KeyboardDetail>();
            foreach (var keyboardDetailName in input.KeyboardDetails)
            {
                KeyboardDetail keyboardDetail = this.GetOrCreateKeyboardDetail(keyboardDetailName);
                keyboardDetails.Add(keyboardDetail);
            }

            var extras = new List<Extra>();
            foreach (var extraName in input.Extras)
            {
                Extra extra = this.GetOrCreateExtra(extraName);
            }

            var laptop = new Laptop
            {
                Name = input.Name,
                Manufacturer = manufacturer,
                Price = input.Price,
                Images = input.Images.Select(x => new Image { Url = x }).ToList(),
                Purpose = purpose,
                Processor = processor,
                Memory = memory,
                MemorySlots = input.MemorySlots,
                VideoCard = videCard,
                HDD = hdd,
                SSD = ssd,
                Display = display,
                Camera = camera,
                Audio = audio,
                OpticalDevice = input.OpticalDevice,
                WiFi = wifi,
                Lan = lan,
                Ports = laptopPorts,
                KeyboardDetails = keyboardDetails,
                Extras = extras,
                OperatingSystem = operatingSystem,
                Battery = battery,
                Weight = input.Weight,
                Demensions = input.Demensions,
                Color = color,
            };

            await this.laptopRepository.AddAsync(laptop);
            await this.laptopRepository.SaveChangesAsync();
        }

        public LaptopPartsViewModel GetAllParts()
        {
            return new LaptopPartsViewModel
            {
                Manufacturers = this.manufacturerRepository.AllAsNoTracking().Select(x => x.Name).ToList(),
                Purposes = this.purposeRepository.AllAsNoTracking().Select(x => x.Name).ToList(),
                Processors = this.processorRepository.AllAsNoTracking().Select(x => x.Name).ToList(),
                Memories = this.memoryRepository.AllAsNoTracking().Select(x => x.Name).ToList(),
                VideoCards = this.videoCardRepository.AllAsNoTracking().Select(x => x.Name).ToList(),
                HDDs = this.hddRepository.AllAsNoTracking().Select(x => x.Name).ToList(),
                SSDs = this.ssdRepository.AllAsNoTracking().Select(x => x.Name).ToList(),
                Displays = this.displayRepository.AllAsNoTracking().Select(x => x.Name).ToList(),
                Cameras = this.cameraRepository.AllAsNoTracking().Select(x => x.Name).ToList(),
                Audios = this.audioRepository.AllAsNoTracking().Select(x => x.Name).ToList(),
                WiFis = this.wifiRepository.AllAsNoTracking().Select(x => x.Name).ToList(),
                Lans = this.lanRepository.AllAsNoTracking().Select(x => x.Name).ToList(),
                Ports = this.portRepository.AllAsNoTracking().Select(x => x.Name).ToList(),
                KeyboardDetails = this.keyboardRepository.AllAsNoTracking().Select(x => x.Name).ToList(),
                Extras = this.extraRepository.AllAsNoTracking().Select(x => x.Name).ToList(),
                OperatingSystems = this.operatinSystemRepository.AllAsNoTracking().Select(x => x.Name).ToList(),
                Batteries = this.batteryRepository.AllAsNoTracking().Select(x => x.Name).ToList(),
                Colors = this.colorRepository.AllAsNoTracking().Select(x => x.Name).ToList(),
            };
        }

        public IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 12)
        {
            var laptops = this.laptopRepository.AllAsNoTracking()
               .OrderBy(x => x.Id)
               .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
               .To<T>().ToList();
            return laptops;
        }

        public T GetById<T>(int id)
        {
            var laptops = this.laptopRepository.AllAsNoTracking()
                .Where(x => x.Id == id)
                .To<T>().FirstOrDefault();

            return laptops;
        }

        public int GetCount()
        {
            return this.laptopRepository.All().Count();
        }

        private Extra GetOrCreateExtra(string extraName)
        {
            var extra = this.extraRepository.AllAsNoTracking()
                   .FirstOrDefault(x => x.Name == extraName);

            if (extra is null)
            {
                extra = new Extra { Name = extraName };
            }

            return extra;
        }

        private KeyboardDetail GetOrCreateKeyboardDetail(string keyboardDetailName)
        {
            var keyboardDetail = this.keyboardRepository.AllAsNoTracking()
                   .FirstOrDefault(x => x.Name == keyboardDetailName);

            if (keyboardDetail is null)
            {
                keyboardDetail = new KeyboardDetail { Name = keyboardDetailName };
            }

            return keyboardDetail;
        }

        private Port GetOrCreatePort(string portName)
        {
            var port = this.portRepository.AllAsNoTracking()
                   .FirstOrDefault(x => x.Name == portName);

            if (port is null)
            {
                port = new Port { Name = portName };
            }

            return port;
        }

        private Color GetOrCreateColor(string colorName)
        {
            var color = this.colorRepository.AllAsNoTracking()
                   .FirstOrDefault(x => x.Name == colorName);

            if (color is null)
            {
                color = new Color { Name = colorName };
            }

            return color;
        }

        private Battery GetOrCreateBattery(string batteryName)
        {
            var battery = this.batteryRepository.AllAsNoTracking()
                   .FirstOrDefault(x => x.Name == batteryName);

            if (battery is null)
            {
                battery = new Battery { Name = batteryName };
            }

            return battery;
        }

        private OpSystem GetOrCreateOperatingSystem(string operatingSystemName)
        {
            var operatingSystem = this.operatinSystemRepository.AllAsNoTracking()
                   .FirstOrDefault(x => x.Name == operatingSystemName);

            if (operatingSystem is null)
            {
                operatingSystem = new OpSystem { Name = operatingSystemName };
            }

            return operatingSystem;
        }

        private Lan GetOrCreateLan(string lanName)
        {
            var lan = this.lanRepository.AllAsNoTracking()
                   .FirstOrDefault(x => x.Name == lanName);

            if (lan is null)
            {
                lan = new Lan { Name = lanName };
            }

            return lan;
        }

        private WiFi GetOrCreateWiFi(string wifiName)
        {
            var wifi = this.wifiRepository.AllAsNoTracking()
                   .FirstOrDefault(x => x.Name == wifiName);

            if (wifi is null)
            {
                wifi = new WiFi { Name = wifiName };
            }

            return wifi;
        }

        private Audio GetOrCreateAudio(string audioName)
        {
            var audio = this.audioRepository.AllAsNoTracking()
                .FirstOrDefault(x => x.Name == audioName);

            if (audio is null)
            {
                audio = new Audio { Name = audioName };
            }

            return audio;
        }

        private Camera GetOrCreateCamera(string cameraName)
        {
            var camera = this.cameraRepository.AllAsNoTracking()
                .FirstOrDefault(x => x.Name == cameraName);

            if (camera is null)
            {
                camera = new Camera { Name = cameraName };
            }

            return camera;
        }

        private Display GetOrCreateDisplay(string displayName)
        {
            var display = this.displayRepository.AllAsNoTracking()
                .FirstOrDefault(x => x.Name == displayName);

            if (display is null)
            {
                display = new Display { Name = displayName };
            }

            return display;
        }

        private SSD GetOrCreateSSD(string ssdName)
        {
            var ssd = this.ssdRepository.AllAsNoTracking()
                .FirstOrDefault(x => x.Name == ssdName);

            if (ssd is null)
            {
                ssd = new SSD { Name = ssdName };
            }

            return ssd;
        }

        private HDD GetOrCreateHDD(string hddName)
        {
            var hdd = this.hddRepository.AllAsNoTracking()
                .FirstOrDefault(x => x.Name == hddName);

            if (hdd is null)
            {
                hdd = new HDD { Name = hddName };
            }

            return hdd;
        }

        private Memory GetOrCreateMemory(string memoryName)
        {
            var memory = this.memoryRepository.AllAsNoTracking()
                .FirstOrDefault(x => x.Name == memoryName);

            if (memory is null)
            {
                memory = new Memory { Name = memoryName };
            }

            return memory;
        }

        private VideoCard GetOrCreateVideoCard(string videoCardName)
        {
            var videoCard = this.videoCardRepository.AllAsNoTracking()
                .FirstOrDefault(x => x.Name == videoCardName);

            if (videoCard is null)
            {
                videoCard = new VideoCard { Name = videoCardName };
            }

            return videoCard;
        }

        private Processor GetOrCreateProcessor(string processorName)
        {
            var processor = this.processorRepository.AllAsNoTracking()
                .FirstOrDefault(x => x.Name == processorName);

            if (processor is null)
            {
                processor = new Processor { Name = processorName };
            }

            return processor;
        }

        private Purpose GetOrCreatePurpose(string purposeName)
        {
            var purpose = this.purposeRepository.AllAsNoTracking()
                .FirstOrDefault(x => x.Name == purposeName);

            if (purpose is null)
            {
                purpose = new Purpose { Name = purposeName };
            }

            return purpose;
        }

        private Manufacturer GetOrCreateManufacturer(string manufacturerName)
        {
            var manufacturer = this.manufacturerRepository.AllAsNoTracking()
                .FirstOrDefault(x => x.Name == manufacturerName);

            if (manufacturer is null)
            {
                manufacturer = new Manufacturer { Name = manufacturerName };
            }

            return manufacturer;
        }
    }
}
