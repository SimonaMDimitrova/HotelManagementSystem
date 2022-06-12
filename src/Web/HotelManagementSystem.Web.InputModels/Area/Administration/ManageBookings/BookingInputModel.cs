namespace HotelManagementSystem.Web.InputModels.Area.Administration.ManageBookings
{
    using System.ComponentModel.DataAnnotations;

    public class BookingInputModel
    {
        public string AccommodationId { get; set; }

        [Required(ErrorMessage = "Enter first name!")]
        [MinLength(3, ErrorMessage = "Name must be more than 3 letters length.")]
        [MaxLength(100, ErrorMessage = "Name must be more than 3 letters length.")]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Enter last name!")]
        [MinLength(3, ErrorMessage = "Surname must be more than 3 letters length.")]
        [MaxLength(100, ErrorMessage = "Surname must be more than 3 letters length.")]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Enter valid number!")]
        [RegularExpression(@"^\s*(?:\+?(\d{1,3}))?[-. (]*(\d{3})[-. )]*(\d{3})[-. ]*(\d{4})(?: *x(\d+))?\s*$", ErrorMessage = "Enter valid number!")]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

        public decimal Price { get; set; }

        public int GuestsCount { get; set; }

        [Required(ErrorMessage = "Enter valid PID.")]
        public string PID { get; set; }

        public int? Days { get; set; }

        [Display(Name = "Is booking paid?")]
        public bool IsPaid { get; set; }

        public IEnumerable<string>? BedTypes { get; set; }

        public IEnumerable<string>? FacilitiesIds { get; set; }

        public IEnumerable<FacilityInputModel>? Facilities { get; set; }
    }
}
