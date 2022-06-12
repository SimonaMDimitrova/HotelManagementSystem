namespace HotelManagementSystem.Web.ViewModels.UserBookings
{
    using System.Collections.Generic;

    public class BookingsListViewModel
    {
        public IEnumerable<BookingViewModel> Bookings { get; set; }
    }
}
