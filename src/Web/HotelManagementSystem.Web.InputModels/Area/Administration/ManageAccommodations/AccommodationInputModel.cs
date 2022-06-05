namespace HotelManagementSystem.Web.InputModels.Area.Administration.ManageAccommodations
{
    using System.ComponentModel.DataAnnotations;

    using HotelManagementSystem.Data.Models;
    using HotelManagementSystem.Services.Mapping;

    public class AccommodationInputModel : IMapFrom<Accommodation>
    {
        public string Id { get; set; }

        public string? Name { get; set; }

        [Range(10, 500)]
        public double AdditionalPrice { get; set; }

        [MinLength(10)]
        [MaxLength(200)]
        public string Description { get; set; }
    }
}
