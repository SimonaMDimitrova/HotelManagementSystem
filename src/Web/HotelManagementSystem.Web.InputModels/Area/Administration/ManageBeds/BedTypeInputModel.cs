namespace HotelManagementSystem.Web.InputModels.Area.Administration.ManageBeds
{
    using System.ComponentModel.DataAnnotations;

    using HotelManagementSystem.Data.Models;
    using HotelManagementSystem.Services.Mapping;

    public class BedTypeInputModel : IMapFrom<BedType>
    {
        public string Id { get; set; }

        public string? Name { get; set; }

        [Range(10, 200)]
        public double Price { get; set; }
    }
}
