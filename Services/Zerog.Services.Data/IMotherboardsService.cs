namespace Zerog.Services.Data
{
    using System.Collections.Generic;
    using Zerog.Web.ViewModels;

    public interface IMotherboardsService
    {
        public void Add(MotherboardDtoModel input);

        IEnumerable<MotherboardDtoModel> GetAll();

        //public bool Delete(int id);

        //public void Edit(int id);

        //public InputProcessorModel Get(int id);
    }
}
