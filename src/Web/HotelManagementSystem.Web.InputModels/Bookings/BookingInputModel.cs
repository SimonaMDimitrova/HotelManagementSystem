namespace HotelManagementSystem.Web.InputModels.Bookings
{
    using System.ComponentModel.DataAnnotations;

    public class BookingInputModel
    {
        public UserInfoInputModel User { get; set; }

        public string AccommodationId { get; set; }

        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

        public decimal Price { get; set; }

        public int GuestsCount { get; set; }

        public int? Days { get; set; }

        [Display(Name = "Is booking paid?")]
        public bool IsPaid { get; set; }

        public IEnumerable<string>? BedTypes { get; set; }

        public IEnumerable<string>? FacilitiesIds { get; set; }

        public IEnumerable<FacilityInputModel>? Facilities { get; set; }
    }
}
