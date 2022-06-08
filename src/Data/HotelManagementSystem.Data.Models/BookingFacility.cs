namespace HotelManagementSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using HotelManagementSystem.Data.Common.Models;

    public class BookingFacility : BaseDeletableModel<string>
    {
        public BookingFacility()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string BookingId { get; set; }

        public virtual Booking Booking { get; set; }

        public string FacilityId { get; set; }

        public virtual Facility Facility { get; set; }
    }
}
