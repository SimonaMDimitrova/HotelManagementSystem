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

        [Range(0, 500)]
        public decimal PricePerDay { get; set; }

        public bool IsAvailable { get; set; }
    }
}
