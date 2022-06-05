namespace HotelManagementSystem.Data.Models
{
    using System;
    using System.Collections.Generic;

    using HotelManagementSystem.Data.Common.Models;

    public class Accommodation : BaseModel<string>
    {
        public Accommodation()
        {
            this.Id = Guid.NewGuid().ToString();
            this.AccommodationBedTypes = new HashSet<AccommodationBedType>();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public double AdditionalPrice { get; set; }

        public int Count { get; set; }

        public string ImageName { get; set; }

        public ICollection<AccommodationBedType> AccommodationBedTypes { get; set; }
    }
}
