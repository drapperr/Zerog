namespace Zerog.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Zerog.Data.Models.LaptopModels;
    using Zerog.Web.ViewModels.Laptops;

    public interface ILaptopService
    {
        Task CreateAsync(CreateLaptopInputModel input);

        IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 12);

        int GetCount();

        T GetById<T>(int id);

        LaptopPartsViewModel GetAllParts();
    }
}
