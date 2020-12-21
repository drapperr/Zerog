namespace Zerog.Services.Data
{
    using System.Threading.Tasks;

    public interface IOrdersService
    {
        Task Add(string userId);
    }
}
