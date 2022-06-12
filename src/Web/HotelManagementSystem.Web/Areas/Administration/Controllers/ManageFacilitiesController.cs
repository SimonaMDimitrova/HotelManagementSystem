namespace HotelManagementSystem.Web.Areas.Administration.Controllers
{
    using System;
    using System.Threading.Tasks;

    using HotelManagementSystem.Services.Data;
    using HotelManagementSystem.Web.InputModels.Area.Administration.ManageFacilities;
    using HotelManagementSystem.Web.ViewModels.Area.Administration.ManageFacilities;
    using Microsoft.AspNetCore.Mvc;

    public class ManageFacilitiesController : AdministrationController
    {
        private readonly IFacilitiesService facilitiesService;

        public ManageFacilitiesController(IFacilitiesService facilitiesService)
        {
            this.facilitiesService = facilitiesService;
        }

        public IActionResult Index()
        {
            var facilities = this.facilitiesService.GetAll<FacilityViewModel>();
            var viewModel = new FacilitiesListViewModel
            {
                Facilities = facilities,
            };

            return this.View(viewModel);
        }

        public IActionResult Edit(string id)
        {
            var viewModel = this.facilitiesService.GetById<FacilityInputModel>(id);
            if (viewModel == null)
            {
                return this.NotFound();
            }

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(FacilityInputModel input)
        {
            input.Name = this.facilitiesService.GetName(input.Id);
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            try
            {
                await this.facilitiesService.EditAsync(input);
            }
            catch (NullReferenceException ex)
            {
                return this.RedirectToAction(nameof(this.Index));
            }

            this.TempData["EditFacility"] = "Successfully edited!";

            return this.RedirectToAction(nameof(this.Index));
        }
    }
}
