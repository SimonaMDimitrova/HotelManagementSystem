namespace HotelManagementSystem.Data.Models
{
    using System;
    using System.Collections.Generic;

    using HotelManagementSystem.Data.Common.Models;

    public class BedType : BaseModel<string>
    {
        public BedType()
        {
            this.Id = Guid.NewGuid().ToString();
            this.AccommodationBedTypes = new HashSet<AccommodationBedType>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public decimal Price { get; set; }

        public virtual ICollection<AccommodationBedType> AccommodationBedTypes { get; set; }
    }
}
