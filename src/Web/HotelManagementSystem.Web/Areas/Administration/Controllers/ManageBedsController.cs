namespace HotelManagementSystem.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using HotelManagementSystem.Services.Data;
    using HotelManagementSystem.Web.InputModels.Area.Administration.ManageBeds;
    using HotelManagementSystem.Web.ViewModels.Area.Administration.ManageBeds;
    using Microsoft.AspNetCore.Mvc;

    public class ManageBedsController : AdministrationController
    {
        private readonly IBedTypesService bedTypesService;

        public ManageBedsController(IBedTypesService bedTypesService)
        {
            this.bedTypesService = bedTypesService;
        }

        public IActionResult Index()
        {
            var beds = this.bedTypesService.GetAll<BedTypeViewModel>();
            var viewModel = new BedTypesListViewModel
            {
                Beds = beds,
            };
            return this.View(viewModel);
        }

        public IActionResult Edit(string id)
        {
            var viewModel = this.bedTypesService.GetById<BedTypeInputModel>(id);
            if (viewModel == null)
            {
                return this.NotFound();
            }

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BedTypeInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.Name = this.bedTypesService.GetNameById(input.Id);
                return this.View(input);
            }

            try
            {
                await this.bedTypesService.EditAsync(input);
            }
            catch (System.Exception)
            {
                return this.RedirectToAction(nameof(this.Index));
            }

            this.TempData["EditBedPrice"] = "Successfully edited!";

            return this.RedirectToAction(nameof(this.Index));
        }
    }
}
