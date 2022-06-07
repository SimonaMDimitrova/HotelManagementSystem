namespace HotelManagementSystem.Web.ViewComponents
{
    using HotelManagementSystem.Services.Data;
    using HotelManagementSystem.Web.ViewModels.ViewComponents.Accommodations;
    using Microsoft.AspNetCore.Mvc;

    public class AccommodationsViewComponent : ViewComponent
    {
        private readonly IAccommodationsService accommodationsService;

        public AccommodationsViewComponent(IAccommodationsService accommodationsService)
        {
            this.accommodationsService = accommodationsService;
        }

        public IViewComponentResult Invoke()
        {
            var accommodations = this.accommodationsService.GetAll<AccommodationViewModel>();
            var viewModel = new AccommodationsListViewModel
            {
                Accommodations = accommodations,
            };

            return this.View(viewModel);
        }
    }
}
