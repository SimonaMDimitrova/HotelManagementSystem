namespace HotelManagementSystem.Web.ViewModels.ViewComponents.Facilities
{
    using HotelManagementSystem.Data.Models;
    using HotelManagementSystem.Services.Mapping;

    public class FacilityViewModel : IMapFrom<Facility>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string FavIconCode { get; set; }

        public decimal PricePerDay { get; set; }

        public bool IsAvailable { get; set; }
    }
}
