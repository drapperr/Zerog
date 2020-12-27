namespace Zerog.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using Zerog.Data.Common.Repositories;
    using Zerog.Data.Models;
    using Zerog.Web.ViewModels.Addresses;

    public class AddresssService : IAddressService
    {
        private readonly IDeletableEntityRepository<Address> addressRepository;

        public AddresssService(IDeletableEntityRepository<Address> addressRepository)
        {
            this.addressRepository = addressRepository;
        }

        public async Task Add(AddressInputModel input, string userId)
        {
            var address = new Address
            {
                UserId = userId,
                FirstName = input.FirstName,
                LastName = input.LastName,
                Country = input.Country,
                City = input.City,
                Addreess = input.Addreess,
                ZipCode = input.ZipCode,
                PhoneNumber = input.PhoneNumber,
            };

            await this.addressRepository.AddAsync(address);
            await this.addressRepository.SaveChangesAsync();
        }

        public async Task Edit(AddressInputModel input, int addressId)
        {
            var adddress = this.addressRepository.All().FirstOrDefault(x => x.Id == addressId);
            adddress.FirstName = input.FirstName;
            adddress.LastName = input.LastName;
            adddress.Country = input.Country;
            adddress.City = input.City;
            adddress.Addreess = input.Addreess;
            adddress.ZipCode = input.ZipCode;
            adddress.PhoneNumber = input.PhoneNumber;

            await this.addressRepository.SaveChangesAsync();
        }

        public AddressViewModel GetById(int id)
        {
            var adddress = this.addressRepository.All()
                .Where(x => x.Id == id)
                .Select(x => new AddressViewModel
                {
                    Id = id,
                    UserId = x.UserId,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Country = x.Country,
                    City = x.City,
                    Addreess = x.Addreess,
                    ZipCode = x.ZipCode,
                    PhoneNumber = x.PhoneNumber,
                }).FirstOrDefault();

            return adddress;
        }

        public AddressViewModel GetByUserId(string id)
        {
            var adddress = this.addressRepository.All()
                .Where(x => x.UserId == id)
                .Select(x => new AddressViewModel
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Country = x.Country,
                    City = x.City,
                    Addreess = x.Addreess,
                    ZipCode = x.ZipCode,
                    PhoneNumber = x.PhoneNumber,
                }).FirstOrDefault();

            return adddress;
        }

        public bool UserHavaAddress(string id)
        {
            return this.addressRepository.All().Any(x => x.UserId == id);
        }
    }
}
