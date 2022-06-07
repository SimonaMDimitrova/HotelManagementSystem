namespace HotelManagementSystem.Data.Models
{
    using System;

    using HotelManagementSystem.Data.Common.Models;

    public class Booking : BaseDeletableModel<string>
    {
        public Booking()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

        public DateTime? CheckInActual { get; set; }

        public DateTime? CheckOutActual { get; set; }

        public bool IsConfirmed { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public virtual Accommodation Accommodation { get; set; }

        public virtual ApplicationUser? ApplicationUser { get; set; }

        public string? ApplicationUserId { get; set; }
    }
}
