namespace HotelManagementSystem.Data.Models
{
    using HotelManagementSystem.Data.Common.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

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

        public bool IsCreditCard { get; set; }

        public bool IsConfirmed { get; set; }

        public bool IsPaid { get; set; }

        public virtual Accommodation Accommodation { get; set; }

        public string AccommodationId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public string ApplicationUserId { get; set; }
    }
}
