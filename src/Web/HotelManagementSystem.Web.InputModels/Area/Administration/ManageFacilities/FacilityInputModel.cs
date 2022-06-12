namespace HotelManagementSystem.Web.InputModels.Area.Administration.ManageFacilities
{
    using System.ComponentModel.DataAnnotations;

    using HotelManagementSystem.Data.Models;
    using HotelManagementSystem.Services.Mapping;

    public class FacilityInputModel : IMapFrom<Facility>
    {
        [Required]
        public string? Id { get; set; }

        public string? Name { get; set; }

        [Range(0, 500, ErrorMessage = "Must be between 0 and 500 dollars.")]
        [Display(Name = "Price per day")]
        public decimal PricePerDay { get; set; }

        [Display(Name = "Is facility available?")]
        public bool IsAvailable { get; set; }
    }
}
