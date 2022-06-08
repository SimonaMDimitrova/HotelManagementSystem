namespace HotelManagementSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using HotelManagementSystem.Data.Common.Models;

    public class Facility : BaseModel<string>
    {
        public Facility()
        {
            this.Id = Guid.NewGuid().ToString();

            this.BookingFacilities = new HashSet<BookingFacility>();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public string FavIconCode { get; set; }

        public decimal PricePerDay { get; set; }

        public bool IsAvailable { get; set; }

        public ICollection<BookingFacility> BookingFacilities { get; set; }
    }
}
