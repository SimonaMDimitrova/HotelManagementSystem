namespace HotelManagementSystem.Web.Controllers
{
    using HotelManagementSystem.Services.Data;
    using HotelManagementSystem.Web.ViewModels.Accommodations;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    public class AccommodationsController : BaseController
    {
        private readonly IAccommodationsService accommodationsService;

        public AccommodationsController(IAccommodationsService accommodationsService)
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
    }
}
