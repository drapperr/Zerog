namespace Zerog.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Zerog.Services.Data;
    using Zerog.Web.ViewModels;

    public class ProductsController : BaseController
    {
        private readonly IMotherboardsService motherboardsService;

        public ProductsController(IMotherboardsService motherboardsService)
        {
            this.motherboardsService = motherboardsService;
        }

        public IActionResult Motherboards()
        {
            var motherboards = this.motherboardsService.GetAll();
            return this.View("ProductsList", motherboards);
        }

        public async Task<IActionResult> Motherboard(int id)
        {
            var motherboard = this.motherboardsService.GetAll().FirstOrDefault();
            return this.View(motherboard);
        }
    }
}
