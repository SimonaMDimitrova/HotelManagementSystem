namespace HotelManagementSystem.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    using HotelManagementSystem.Services.Data;

    using HotelManagementSystem.Web.InputModels.Bookings;
    using HotelManagementSystem.Web.ViewModels;
    using HotelManagementSystem.Web.ViewModels.Bookings;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly IAccommodationsService accommodationsService;
        private readonly IBedTypesService bedTypesService;
        private readonly IFacilitiesService facilitiesService;
        private readonly IBookingsService bookingsService;
        private readonly IUsersService usersService;

        public HomeController(
            IAccommodationsService accommodationsService,
            IBedTypesService bedTypesService,
            IFacilitiesService facilitiesService,
            IBookingsService bookingsService,
            IUsersService usersService)
        {
            this.accommodationsService = accommodationsService;
            this.bedTypesService = bedTypesService;
            this.facilitiesService = facilitiesService;
            this.bookingsService = bookingsService;
            this.usersService = usersService;
        }

        public IActionResult Index()
        {
            this.ViewData["IsUserOnHomePage"] = true;

            return this.View();
        }

        public IActionResult Search(InputModels.Area.Administration.ManageBookings.AccommodationSearchInputModel<AccommodationViewModel> input)
        {
            this.ViewData["IsUserOnHomePage"] = true;
            IEnumerable<AccommodationViewModel> accommodations = null;

            if (input.CheckIn <= DateTime.UtcNow.AddDays(5))
            {
                input.Accommodations = accommodations;
                return this.View(input);
            }

            accommodations = this.accommodationsService.GetAvailable<AccommodationViewModel>(input);
            if (accommodations != null)
            {
                input.Accommodations = accommodations;
                input.Days = (int)(input.CheckOut - input.CheckIn)?.TotalDays;

                foreach (var accommodation in accommodations)
                {
                    accommodation.Price *= input.Days;
                }
            }

            return this.View(input);
        }

        public IActionResult Add(string id, DateTime checkIn, DateTime checkOut, decimal price, int guestsCount)
        {
            var username = this.User.Identity.Name;

            var viewModel = new BookingInputModel
            {
                AccommodationId = id,
                CheckIn = checkIn,
                CheckOut = checkOut,
                GuestsCount = guestsCount,
                Price = price,
                Days = (checkOut.Date - checkIn.Date).Days,
            };

            var userInfo = this.usersService.GetPreviousResults(username);
            if (userInfo != null)
            {
                viewModel.User = userInfo;
            }

            var facilities = this.facilitiesService.GetAllAvailable<FacilityInputModel>();
            var bedTypes = this.bedTypesService.GetAllByAccommodationId(id);

            viewModel.Facilities = facilities;
            viewModel.BedTypes = bedTypes;

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(BookingInputModel input)
        {
            var username = this.User.Identity.Name;
            input.User.Username = username;
            if (!this.ModelState.IsValid)
            {
                var facilities = this.facilitiesService.GetAll<FacilityInputModel>();
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

            await this.bookingsService.AddWithUserAsync(input);

            this.TempData["SuccessBooked"] = "Successfully booked!";

            return this.RedirectToAction("Index", "Bookings");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
