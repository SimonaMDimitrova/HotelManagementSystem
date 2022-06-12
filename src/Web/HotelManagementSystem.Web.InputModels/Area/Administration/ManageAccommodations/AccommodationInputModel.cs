namespace HotelManagementSystem.Web.InputModels.Area.Administration.ManageAccommodations
{
    using System.ComponentModel.DataAnnotations;

    using HotelManagementSystem.Data.Models;
    using HotelManagementSystem.Services.Mapping;

    public class AccommodationInputModel : IMapFrom<Accommodation>
    {
        public string Id { get; set; }

        public string? Name { get; set; }

        [Range(10, 500, ErrorMessage = "Must be between 10 and 500 dollars.")]
        [Display(Name = "Additional price")]
        public decimal AdditionalPrice { get; set; }

        [Required(ErrorMessage = "Insert description!")]
        [MinLength(10, ErrorMessage = "Must be at least 10 letters length.")]
        [MaxLength(200, ErrorMessage = "Must not be more than 200 letters length.")]
        public string Description { get; set; }
    }
}
