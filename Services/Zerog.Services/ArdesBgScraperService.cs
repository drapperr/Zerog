namespace Zerog.Services
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using Newtonsoft.Json;
    using Zerog.Data.Common.Repositories;
    using Zerog.Data.Models.LaptopModels;
    using Zerog.Web.ViewModels.Laptops;

    public class ArdesBgScraperService : IArdesBgScraperService
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

        public ArdesBgScraperService(
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

        public async Task ImportRecipesAsync()
        {
            var json = File.ReadAllText("C:/Users/User/OneDrive/Desktop/Projects/ArdesScraper/ArdesScraper/JsonsData/laptops.json");
            var laptopModels = JsonConvert.DeserializeObject<List<LaptopDtoModel>>(json);
            foreach (var laptop in laptopModels)
            {
                await this.AddAsync(laptop);
            }
        }

        public async Task AddAsync(LaptopDtoModel input)
        {
            Manufacturer manufacturer = await this.GetOrCreateManufacturer(input.Manufacturer);
            Purpose purpose = await this.GetOrCreatePurpose(input.Purpose);
            Processor processor = await this.GetOrCreateProcessor(input.Processor);
            VideoCard videCard = await this.GetOrCreateVideoCard(input.VideoCard);
            Memory memory = await this.GetOrCreateMemory(input.Memory);
            HDD hdd = await this.GetOrCreateHDD(input.HDD);
            SSD ssd = await this.GetOrCreateSSD(input.SSD);
            Display display = await this.GetOrCreateDisplay(input.Display);
            Camera camera = await this.GetOrCreateCamera(input.Camera);
            Audio audio = await this.GetOrCreateAudio(input.Audio);
            WiFi wifi = await this.GetOrCreateWiFi(input.WiFi);
            Lan lan = await this.GetOrCreateLan(input.Lan);
            OpSystem operatingSystem = await this.GetOrCreateOperatingSystem(input.OperatingSystem);
            Battery battery = await this.GetOrCreateBattery(input.Battery);
            Color color = await this.GetOrCreateColor(input.Color);

            var laptopPorts = new List<LaptopPort>();
            foreach (var portModel in input.Ports)
            {
                Port port = await this.GetOrCreatePort(portModel.Name);
                laptopPorts.Add(new LaptopPort { Port = port, Count = portModel.Count });
            }

            var keyboardDetails = new List<KeyboardDetail>();
            foreach (var keyboardDetailName in input.KeyboardDetails)
            {
                KeyboardDetail keyboardDetail = await this.GetOrCreateKeyboardDetail(keyboardDetailName);
                keyboardDetails.Add(keyboardDetail);
            }

            var extras = new List<Extra>();
            foreach (var extraName in input.Extras)
            {
                Extra extra = await this.GetOrCreateExtra(extraName);
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

        private async Task<Extra> GetOrCreateExtra(string extraName)
        {
            var extra = this.extraRepository.All()
                   .FirstOrDefault(x => x.Name == extraName);

            if (extra is null)
            {
                extra = new Extra { Name = extraName };
                await this.extraRepository.AddAsync(extra);
                await this.extraRepository.SaveChangesAsync();
            }

            return extra;
        }

        private async Task<KeyboardDetail> GetOrCreateKeyboardDetail(string keyboardDetailName)
        {
            var keyboardDetail = this.keyboardRepository.All()
                   .FirstOrDefault(x => x.Name == keyboardDetailName);

            if (keyboardDetail is null)
            {
                keyboardDetail = new KeyboardDetail { Name = keyboardDetailName };
                await this.keyboardRepository.AddAsync(keyboardDetail);
                await this.keyboardRepository.SaveChangesAsync();
            }

            return keyboardDetail;
        }

        private async Task<Port> GetOrCreatePort(string portName)
        {
            var port = this.portRepository.All()
                   .FirstOrDefault(x => x.Name == portName);

            if (port is null)
            {
                port = new Port { Name = portName };
                await this.portRepository.AddAsync(port);
                await this.portRepository.SaveChangesAsync();
            }

            return port;
        }

        private async Task<Color> GetOrCreateColor(string colorName)
        {
            var color = this.colorRepository.All()
                   .FirstOrDefault(x => x.Name == colorName);

            if (color is null)
            {
                color = new Color { Name = colorName };
                await this.colorRepository.AddAsync(color);
                await this.colorRepository.SaveChangesAsync();
            }

            return color;
        }

        private async Task<Battery> GetOrCreateBattery(string batteryName)
        {
            var battery = this.batteryRepository.All()
                   .FirstOrDefault(x => x.Name == batteryName);

            if (battery is null)
            {
                battery = new Battery { Name = batteryName };
                await this.batteryRepository.AddAsync(battery);
                await this.batteryRepository.SaveChangesAsync();
            }

            return battery;
        }

        private async Task<OpSystem> GetOrCreateOperatingSystem(string operatingSystemName)
        {
            var operatingSystem = this.operatinSystemRepository.All()
                   .FirstOrDefault(x => x.Name == operatingSystemName);

            if (operatingSystem is null)
            {
                operatingSystem = new OpSystem { Name = operatingSystemName };
                await this.operatinSystemRepository.AddAsync(operatingSystem);
                await this.operatinSystemRepository.SaveChangesAsync();
            }

            return operatingSystem;
        }

        private async Task<Lan> GetOrCreateLan(string lanName)
        {
            var lan = this.lanRepository.All()
                   .FirstOrDefault(x => x.Name == lanName);

            if (lan is null)
            {
                lan = new Lan { Name = lanName };
                await this.lanRepository.AddAsync(lan);
                await this.lanRepository.SaveChangesAsync();
            }

            return lan;
        }

        private async Task<WiFi> GetOrCreateWiFi(string wifiName)
        {
            var wifi = this.wifiRepository.All()
                   .FirstOrDefault(x => x.Name == wifiName);

            if (wifi is null)
            {
                wifi = new WiFi { Name = wifiName };
                await this.wifiRepository.AddAsync(wifi);
                await this.wifiRepository.SaveChangesAsync();
            }

            return wifi;
        }

        private async Task<Audio> GetOrCreateAudio(string audioName)
        {
            var audio = this.audioRepository.All()
                .FirstOrDefault(x => x.Name == audioName);

            if (audio is null)
            {
                audio = new Audio { Name = audioName };
                await this.audioRepository.AddAsync(audio);
                await this.audioRepository.SaveChangesAsync();
            }

            return audio;
        }

        private async Task<Camera> GetOrCreateCamera(string cameraName)
        {
            var camera = this.cameraRepository.All()
                .FirstOrDefault(x => x.Name == cameraName);

            if (camera is null)
            {
                camera = new Camera { Name = cameraName };
                await this.cameraRepository.AddAsync(camera);
                await this.cameraRepository.SaveChangesAsync();
            }

            return camera;
        }

        private async Task<Display> GetOrCreateDisplay(string displayName)
        {
            var display = this.displayRepository.All()
                .FirstOrDefault(x => x.Name == displayName);

            if (display is null)
            {
                display = new Display { Name = displayName };
                await this.displayRepository.AddAsync(display);
                await this.displayRepository.SaveChangesAsync();
            }

            return display;
        }

        private async Task<SSD> GetOrCreateSSD(string ssdName)
        {
            var ssd = this.ssdRepository.All()
                .FirstOrDefault(x => x.Name == ssdName);

            if (ssd is null)
            {
                ssd = new SSD { Name = ssdName };
                await this.ssdRepository.AddAsync(ssd);
                await this.ssdRepository.SaveChangesAsync();
            }

            return ssd;
        }

        private async Task<HDD> GetOrCreateHDD(string hddName)
        {
            var hdd = this.hddRepository.All()
                .FirstOrDefault(x => x.Name == hddName);

            if (hdd is null)
            {
                hdd = new HDD { Name = hddName };
                await this.hddRepository.AddAsync(hdd);
                await this.hddRepository.SaveChangesAsync();
            }

            return hdd;
        }

        private async Task<Memory> GetOrCreateMemory(string memoryName)
        {
            var memory = this.memoryRepository.All()
                .FirstOrDefault(x => x.Name == memoryName);

            if (memory is null)
            {
                memory = new Memory { Name = memoryName };
                await this.memoryRepository.AddAsync(memory);
                await this.memoryRepository.SaveChangesAsync();
            }

            return memory;
        }

        private async Task<VideoCard> GetOrCreateVideoCard(string videoCardName)
        {
            var videoCard = this.videoCardRepository.All()
                .FirstOrDefault(x => x.Name == videoCardName);

            if (videoCard is null)
            {
                videoCard = new VideoCard { Name = videoCardName };
                await this.videoCardRepository.AddAsync(videoCard);
                await this.videoCardRepository.SaveChangesAsync();
            }

            return videoCard;
        }

        private async Task<Processor> GetOrCreateProcessor(string processorName)
        {
            var processor = this.processorRepository.All()
                .FirstOrDefault(x => x.Name == processorName);

            if (processor is null)
            {
                processor = new Processor { Name = processorName };
                await this.processorRepository.AddAsync(processor);
                await this.processorRepository.SaveChangesAsync();
            }

            return processor;
        }

        private async Task<Purpose> GetOrCreatePurpose(string purposeName)
        {
            var purpose = this.purposeRepository.All()
                .FirstOrDefault(x => x.Name == purposeName);

            if (purpose is null)
            {
                purpose = new Purpose { Name = purposeName };
                await this.purposeRepository.AddAsync(purpose);
                await this.purposeRepository.SaveChangesAsync();
            }

            return purpose;
        }

        private async Task<Manufacturer> GetOrCreateManufacturer(string manufacturerName)
        {
            var manufacturer = this.manufacturerRepository.All()
                .FirstOrDefault(x => x.Name == manufacturerName);

            if (manufacturer is null)
            {
                manufacturer = new Manufacturer { Name = manufacturerName };
                await this.manufacturerRepository.AddAsync(manufacturer);
                await this.manufacturerRepository.SaveChangesAsync();
            }

            return manufacturer;
        }
    }
}
