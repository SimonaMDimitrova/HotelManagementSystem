namespace HotelManagementSystem.Web.InputModels.Area.Administration.ManageBookings
{
    using System.ComponentModel.DataAnnotations;

    public class BookingInputModel
    {
        public string AccommodationId { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]

        [MinLength(3)]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(@"^\s*(?:\+?(\d{1,3}))?[-. (]*(\d{3})[-. )]*(\d{3})[-. ]*(\d{4})(?: *x(\d+))?\s*$")]
        public string PhoneNumber { get; set; }

        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

        public double Price { get; set; }

        public int GuestsCount { get; set; }

        public int Days { get; set; }

        public IEnumerable<BedTypeInputModel>? BedTypes { get; set; }

        public IEnumerable<string> FacilitiesIds { get; set; }

        public IEnumerable<FacilityInputModel>? Facilities { get; set; }
    }
}
