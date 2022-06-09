namespace HotelManagementSystem.Web.ViewModels.Area.Administration.ManageBookings
{
    using System.Collections.Generic;

    public class BookingsListViewModel
    {
        public IEnumerable<BookingViewModel> Bookings { get; set; }
    }
}
