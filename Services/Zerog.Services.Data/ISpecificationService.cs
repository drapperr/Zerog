namespace Zerog.Services.Data
{
    using System.Collections.Generic;

    public interface ISpecificationService
    {
        Dictionary<string, List<string>> GetAllByProductId(int id);
    }
}
