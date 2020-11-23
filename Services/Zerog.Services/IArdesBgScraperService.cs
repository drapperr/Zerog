namespace Zerog.Services
{
    using System.Threading.Tasks;

    public interface IArdesBgScraperService
    {
        Task ImportRecipesAsync();
    }
}
