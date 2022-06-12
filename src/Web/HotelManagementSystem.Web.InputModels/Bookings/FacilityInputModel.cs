namespace HotelManagementSystem.Web.InputModels.Bookings
{
    using HotelManagementSystem.Data.Models;
    using HotelManagementSystem.Services.Mapping;

    public class FacilityInputModel : IMapFrom<Facility>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public decimal PricePerDay { get; set; }
    }
}
