namespace HotelManagementSystem.Web.ViewModels.Area.Administration.ManageFacilities
{
    using AutoMapper;
    using HotelManagementSystem.Data.Models;
    using HotelManagementSystem.Services.Mapping;

    public class FacilityViewModel : IMapFrom<Facility>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal PricePerDay { get; set; }

        public string FavIconCode { get; set; }

        public string IsAvailable { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Facility, FacilityViewModel>()
                .ForMember(x => x.IsAvailable, opt =>
                    opt.MapFrom(x => x.IsAvailable ? "Yes" : "No"));
        }
    }
}
