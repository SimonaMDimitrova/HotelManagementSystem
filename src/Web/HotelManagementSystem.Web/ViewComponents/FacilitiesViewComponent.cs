namespace HotelManagementSystem.Web.ViewComponents
{
    using HotelManagementSystem.Services.Data;
    using HotelManagementSystem.Web.ViewModels.ViewComponents.Facilities;
    using Microsoft.AspNetCore.Mvc;

    public class FacilitiesViewComponent : ViewComponent
    {
        private readonly IFacilitiesService facilitiesService;

        public FacilitiesViewComponent(IFacilitiesService facilitiesService)
        {
            this.facilitiesService = facilitiesService;
        }

        public IViewComponentResult Invoke()
        {
            var facilities = this.facilitiesService
                .GetAll<FacilityViewModel>();
            var viewModel = new FacilitiesListViewModel
            {
                Facilities = facilities,
            };

            return this.View(viewModel);
        }
    }
}
