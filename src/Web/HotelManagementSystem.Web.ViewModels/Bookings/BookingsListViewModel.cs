namespace HotelManagementSystem.Web.ViewModels.Bookings
{
    using System.Collections.Generic;

    public class BookingsListViewModel
    {
        public IEnumerable<BookingViewModel> Bookings { get; set; }
    }
}
