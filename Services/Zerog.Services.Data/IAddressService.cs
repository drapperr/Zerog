namespace Zerog.Services.Data
{
    using System.Threading.Tasks;

    using Zerog.Web.ViewModels.Addresses;

    public interface IAddressService
    {
        Task Add(AddressInputModel input, string userId);

        AddressViewModel GetById(int id);

        AddressViewModel GetByUserId(string id);

        bool UserHavaAddress(string id);

        Task Edit(AddressInputModel input, int addressId);
    }
}
