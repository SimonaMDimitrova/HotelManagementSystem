namespace HotelManagementSystem.Web.Areas.Administration.Controllers
{
    using System;
    using System.Threading.Tasks;

    using HotelManagementSystem.Services.Data;
    using HotelManagementSystem.Web.InputModels.Area.Administration.ManageAccommodations;
    using HotelManagementSystem.Web.ViewModels.Area.Administration.ManageAccommodations;
    using Microsoft.AspNetCore.Mvc;

    public class ManageAccommodationsController : AdministrationController
    {
        private readonly IAccommodationsService accommodationsService;

        public ManageAccommodationsController(IAccommodationsService accommodationsService)
        {
            this.accommodationsService = accommodationsService;
        }

        public IActionResult Index()
        {
            var accommodations = this.accommodationsService.GetAll<AccommodationViewModel>();
            var viewModel = new AccommodationsListViewModel
            {
                Accommodations = accommodations,
            };
            return this.View(viewModel);
        }

        public IActionResult Edit(string id)
        {
            var viewModel = this.accommodationsService.GetById<AccommodationInputModel>(id);
            if (viewModel == null)
            {
                return this.NotFound();
            }

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AccommodationInputModel input)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    input.Name = this.accommodationsService.GetName(input.Id);
                    return this.View(input);
                }

                await this.accommodationsService.EditAsync(input);
            }
            catch (NullReferenceException ex)
            {
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.RedirectToAction(nameof(this.Index));
        }
    }
}
