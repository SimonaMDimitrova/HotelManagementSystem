namespace HotelManagementSystem.Web.Areas.Administration.Controllers
{
    using System;

    using HotelManagementSystem.Services.Data;
    using HotelManagementSystem.Web.InputModels.Area.Administration.ManageBookings;
    using HotelManagementSystem.Web.ViewModels.Area.Administration.ManageBookings;
    using Microsoft.AspNetCore.Mvc;

    public class ManageBookingsController : ReceptionistController
    {
        private readonly IAccommodationsService accommodationsService;

        public ManageBookingsController(IAccommodationsService accommodationsService)
        {
            this.accommodationsService = accommodationsService;
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
                Id = id,
                CheckIn = checkIn,
                CheckOut = checkOut,
                GuestsCount = guestsCount,
                Price = price,
            };

            return this.View(viewModel);
        }
    }
}
