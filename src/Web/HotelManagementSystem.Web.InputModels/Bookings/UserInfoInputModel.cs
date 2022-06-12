namespace HotelManagementSystem.Web.InputModels.Bookings
{
    using System.ComponentModel.DataAnnotations;

    public class UserInfoInputModel
    {

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

        [Required(ErrorMessage = "Enter valid PID.")]
        public string PID { get; set; }

        public string? Username { get; set; }
    }
}
