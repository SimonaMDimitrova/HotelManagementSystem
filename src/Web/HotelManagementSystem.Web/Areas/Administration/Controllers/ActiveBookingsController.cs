namespace HotelManagementSystem.Web.Areas.Administration.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using HotelManagementSystem.Services.Data;
    using HotelManagementSystem.Web.InputModels.Area.Administration.ManageBookings;
    using HotelManagementSystem.Web.ViewModels.Area.Administration.ManageBookings;
    using Microsoft.AspNetCore.Mvc;

    public class ActiveBookingsController : ReceptionistController
    {
        private readonly IAccommodationsService accommodationsService;
        private readonly IBedTypesService bedTypesService;
        private readonly IFacilitiesService facilitiesService;
        private readonly IBookingsService bookingsService;

        public ActiveBookingsController(
            IAccommodationsService accommodationsService,
            IBedTypesService bedTypesService,
            IFacilitiesService facilitiesService,
            IBookingsService bookingsService)
        {
            this.accommodationsService = accommodationsService;
            this.bedTypesService = bedTypesService;
            this.facilitiesService = facilitiesService;
            this.bookingsService = bookingsService;
        }

        public IActionResult Index()
        {
            var bookings = this.bookingsService.GetAllActive<BookingViewModel>();
            var viewModel = new BookingsListViewModel
            {
                Bookings = bookings,
            };

            return this.View(viewModel);
        }

        public IActionResult Search(AccommodationSearchInputModel<AccommodationViewModel> input)
        {
            var accommodations = this.accommodationsService.GetAvailable<AccommodationViewModel>(input);
            if (accommodations != null)
            {
                input.Accommodations = accommodations;
                input.Days = (int)(input.CheckOut - input.CheckIn)?.TotalDays;
            }

            return this.View(input);
        }

        public IActionResult Add(string id, DateTime checkIn, DateTime checkOut, decimal price, int guestsCount)
        {
            var viewModel = new BookingInputModel
            {
                AccommodationId = id,
                CheckIn = checkIn,
                CheckOut = checkOut,
                GuestsCount = guestsCount,
                Price = price,
                Days = (checkOut.Date - checkIn.Date).Days,
            };

            var facilities = this.facilitiesService.GetAllAvailable<FacilityInputModel>();
            var bedTypes = this.bedTypesService.GetAllByAccommodationId(id);

            viewModel.Facilities = facilities;
            viewModel.BedTypes = bedTypes;

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(BookingInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                var facilities = this.facilitiesService.GetAllAvailable<FacilityInputModel>();
                var bedTypes = this.bedTypesService.GetAllByAccommodationId(input.AccommodationId);

                input.Facilities = facilities;
                input.BedTypes = bedTypes;
                input.Days = (input.CheckOut - input.CheckIn).Days;

                if (input.FacilitiesIds != null)
                {
                    input.Price += (decimal)facilities.Where(x => input.FacilitiesIds.Contains(x.Id)).Sum(x => x.PricePerDay * input.Days);
                }

                return this.View(input);
            }

            await this.bookingsService.AddWithoutUserAsync(input);

            this.TempData["AddBookingAdmin"] = "Successfully added!";

            return this.RedirectToAction(nameof(this.Index));
        }

        public IActionResult Status(string id)
        {
            var viewModel = this.bookingsService.GetStatus(id);

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Status(BookingStatusInputModel input)
        {
            try
            {
                await this.bookingsService.EditAsync(input);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(nameof(input.CheckIn), ex.Message);
                return this.View(input);
            }

            this.TempData["ChangedStatus"] = "Changed status!";

            return this.RedirectToAction(nameof(this.Index));
        }

        [HttpPost]
        public async Task<IActionResult> Cancel(string id)
        {
            await this.bookingsService.CancelAsync(id);

            this.TempData["DeleteBookingAdmin"] = "Successfully deleted!";

            return this.RedirectToAction(nameof(this.Index));
        }
    }
}
