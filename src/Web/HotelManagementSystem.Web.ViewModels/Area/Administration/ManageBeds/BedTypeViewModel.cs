namespace HotelManagementSystem.Web.ViewModels.Area.Administration.ManageBeds
{
    using HotelManagementSystem.Data.Models;
    using HotelManagementSystem.Services.Mapping;

    public class BedTypeViewModel : IMapFrom<BedType>
    {
        public string Name { get; set; }

        public double Price { get; set; }
    }
}
