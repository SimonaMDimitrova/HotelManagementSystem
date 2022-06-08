namespace HotelManagementSystem.Web.InputModels.Area.Administration.ManageBookings
{
    using HotelManagementSystem.Data.Models;
    using HotelManagementSystem.Services.Mapping;

    public class BedTypeInputModel : IMapFrom<BedType>
    {
        public string Name { get; set; }
    }
}
