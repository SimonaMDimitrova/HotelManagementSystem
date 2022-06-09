namespace HotelManagementSystem.Web.InputModels.Area.Administration.ManageBookings
{
    using System;

    using HotelManagementSystem.Data.Models;
    using HotelManagementSystem.Services.Mapping;

    public class EditBookingViewModel : IMapFrom<Booking>
    {
        public string Id { get; set; }

        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }
    }
}
