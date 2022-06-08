namespace HotelManagementSystem.Web.Areas.Administration.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using HotelManagementSystem.Services.Data;
    using HotelManagementSystem.Web.InputModels.Area.Administration.ManageBookings;
    using HotelManagementSystem.Web.ViewModels.Area.Administration.ManageBookings;
    using Microsoft.AspNetCore.Mvc;

    public class ManageBookingsController : ReceptionistController
    {
        private readonly IAccommodationsService accommodationsService;
        private readonly IBedTypesService bedTypesService;
        private readonly IFacilitiesService facilitiesService;
        private readonly IBookingsService bookingsService;

        public ManageBookingsController(
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

        public IActionResult Index(AccommodationSearchInputModel<AccommodationViewModel> input)
        {
            var accommodations = this.accommodationsService.GetAvailable<AccommodationViewModel>(input);
            if (accommodations != null)
            {
                input.Accommodations = accommodations;
                input.Days = (int)(input.CheckOut - input.CheckIn)?.TotalDays;
            }

            return this.View(input);
        }

        public IActionResult Add(string id, DateTime checkIn, DateTime checkOut, double price, int guestsCount)
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

            var facilities = this.facilitiesService.GetAll<FacilityInputModel>();
            var bedTypes = this.bedTypesService.GetAll<BedTypeInputModel>();

            viewModel.Facilities = facilities;
            viewModel.BedTypes = bedTypes;

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(BookingInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                var facilities = this.facilitiesService.GetAll<FacilityInputModel>();
                var bedTypes = this.bedTypesService.GetAll<BedTypeInputModel>();


                input.Facilities = facilities;
                input.BedTypes = bedTypes;
                input.Days = (input.CheckOut - input.CheckIn).Days;

                input.Price += (double)facilities.Where(x => input.FacilitiesIds.Contains(x.Id)).Sum(x => x.PricePerDay * input.Days);

                return this.View(input);
            }

            await this.bookingsService.AddAsync(input);

            return this.RedirectToAction(nameof(this.Index));
        }
    }
}
