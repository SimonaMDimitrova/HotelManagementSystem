namespace HotelManagementSystem.Web.InputModels.Area.Administration.ManageBookings
{
    using System.ComponentModel.DataAnnotations;

    public class BookingInputModel
    {
        public string Id { get; set; }

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
    }
}
