namespace HotelManagementSystem.Data.Models
{
    using System;

    using HotelManagementSystem.Data.Common.Models;

    public class AccommodationBedType : BaseModel<string>
    {
        public AccommodationBedType()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public virtual BedType? BedType { get; set; }

        public string BedTypeId { get; set; }

        public virtual Accommodation? Accommodation { get; set; }

        public string AccommodationId { get; set; }
    }
}
