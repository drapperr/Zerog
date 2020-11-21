namespace Zerog.Services.Data
{
    using System.Collections.Generic;
    using Zerog.Web.ViewModels;

    public interface IMotherboardsService
    {
        public void Add(MotherboardViewModel input);

        IEnumerable<MotherboardViewModel> GetAll();

        //public bool Delete(int id);

        //public void Edit(int id);

        //public InputProcessorModel Get(int id);
    }
}
