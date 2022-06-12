namespace HotelManagementSystem.Data.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using HotelManagementSystem.Data.Common.Models;

    public class Booking : BaseDeletableModel<string>
    {
        public Booking()
        {
            this.Id = Guid.NewGuid().ToString();

            this.BookingFacilities = new HashSet<BookingFacility>();
        }

        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

        public DateTime? ActualCheckIn { get; set; }

        public DateTime? ActualCheckOut { get; set; }

        public bool IsPaid { get; set; }

        public decimal Price { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string PID { get; set; }

        public virtual Accommodation Accommodation { get; set; }

        public string AccommodationId { get; set; }

        public virtual ApplicationUser? ApplicationUser { get; set; }

        public string? ApplicationUserId { get; set; }

        public ICollection<BookingFacility> BookingFacilities { get; set; }
    }
}
