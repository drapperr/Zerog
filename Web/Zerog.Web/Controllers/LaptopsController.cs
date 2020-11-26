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
            var parts = this.laptopService.GetAllParts();
            var inputModel = new CreateLaptopInputModel { Parts = parts };
            return this.View(inputModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateLaptopInputModel input)
        {
            await this.laptopService.CreateAsync(input);

            return this.Redirect("/");
        }

        public IActionResult All(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            const int ItemsPerPage = 12;
            var viewModel = new LaptopListViewModel
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                LaptopsCount = this.laptopService.GetCount(),
                Laptops = this.laptopService.GetAll<LaptopInListViewModel>(id, ItemsPerPage),
            };

            return this.View(viewModel);
        }

        public IActionResult ById(int id)
        {
            var laptop = this.laptopService.GetById<SingleLaptopViewModel>(id);
            return this.View(laptop);
        }
    }
}
