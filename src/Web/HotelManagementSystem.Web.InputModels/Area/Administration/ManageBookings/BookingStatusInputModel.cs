namespace HotelManagementSystem.Web.InputModels.Area.Administration.ManageBookings
{
    using System.ComponentModel.DataAnnotations;

    public class BookingStatusInputModel
    {
        public string Id { get; set; }

        [Display(Name = "Check in")]
        public DateTime? CheckIn { get; set; }

        [Display(Name = "Check in")]
        public DateTime? CheckOut { get; set; }

        [Display(Name = "Is paid")]
        public bool IsPaid { get; set; }
    }
}
