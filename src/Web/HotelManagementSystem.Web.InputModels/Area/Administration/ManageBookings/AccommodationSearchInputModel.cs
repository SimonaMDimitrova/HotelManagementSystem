namespace HotelManagementSystem.Web.InputModels.Area.Administration.ManageBookings
{
    using System;
    using System.Collections.Generic;

    public class AccommodationSearchInputModel<T>
    {
        public DateTime? CheckIn { get; set; } = null;

        public DateTime? CheckOut { get; set; } = null;

        public int GuestsCount { get; set; }

        public int Days { get; set; }

        public IEnumerable<T>? Accommodations { get; set; }
    }
}
