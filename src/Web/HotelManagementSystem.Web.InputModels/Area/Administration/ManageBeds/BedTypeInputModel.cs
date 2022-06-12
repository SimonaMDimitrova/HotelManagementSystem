namespace HotelManagementSystem.Web.InputModels.Area.Administration.ManageBeds
{
    using System.ComponentModel.DataAnnotations;

    using HotelManagementSystem.Data.Models;
    using HotelManagementSystem.Services.Mapping;

    public class BedTypeInputModel : IMapFrom<BedType>
    {
        public string Id { get; set; }

        public string? Name { get; set; }

        [Range(10, 200, ErrorMessage = "Price must be between 10 and 200 dolars.")]
        public decimal Price { get; set; }
    }
}
