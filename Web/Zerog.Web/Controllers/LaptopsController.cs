namespace Zerog.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Zerog.Services.Data;
    using Zerog.Web.ViewModels.Laptops;

    public class LaptopsController : BaseController
    {
        private readonly ILaptopService laptopService;

        public LaptopsController(ILaptopService laptopService)
        {
            this.laptopService = laptopService;
        }

        public IActionResult Create()
        {
            var viewModel = new CreateLaptopInputModel();
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateLaptopInputModel input)
        {
            await this.laptopService.CreateAsync(input);

            return this.Redirect("/");
        }
    }
}
