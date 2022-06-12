namespace HotelManagementSystem.Web.Controllers
{
    using HotelManagementSystem.Services.Data;
    using HotelManagementSystem.Web.ViewModels.Bookings;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class BookingsController : BaseController
    {
        private readonly IBookingsService bookingsService;

        public BookingsController(IBookingsService bookingsService)
        {
            this.bookingsService = bookingsService;
        }

        public IActionResult Index()
        {
            var userId = this.User.Identity.Name;
            var bookings = this.bookingsService.GetByUserId<BookingViewModel>(userId);

            var viewModel = new BookingsListViewModel
            {
                Bookings = bookings,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Cancel(string id)
        {
            await this.bookingsService.CancelAsync(id);

            this.TempData["SuccessCancel"] = "Successfully canceled!";

            return this.RedirectToAction(nameof(this.Index));
        }
    }
}
