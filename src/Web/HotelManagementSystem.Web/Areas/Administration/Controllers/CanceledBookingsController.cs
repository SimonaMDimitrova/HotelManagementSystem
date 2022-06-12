namespace HotelManagementSystem.Web.Areas.Administration.Controllers
{
    using HotelManagementSystem.Services.Data;
    using HotelManagementSystem.Web.ViewModels.Area.Administration.ManageBookings;
    using Microsoft.AspNetCore.Mvc;

    public class CanceledBookingsController : ReceptionistController
    {
        private readonly IBookingsService bookingsService;

        public CanceledBookingsController(IBookingsService bookingsService)
        {
            this.bookingsService = bookingsService;
        }

        public IActionResult Index()
        {
            var bookings = this.bookingsService.GetAllCanceled<BookingViewModel>();
            var viewModel = new BookingsListViewModel
            {
                Bookings = bookings,
            };

            return this.View(viewModel);
        }
    }
}
