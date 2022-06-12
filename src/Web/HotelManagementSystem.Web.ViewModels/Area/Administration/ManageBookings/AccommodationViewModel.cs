namespace HotelManagementSystem.Web.ViewModels.Area.Administration.ManageBookings
{
    using System.Linq;

    using AutoMapper;
    using HotelManagementSystem.Data.Models;
    using HotelManagementSystem.Services.Mapping;

    public class AccommodationViewModel : IMapFrom<Accommodation>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string ImageName { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Accommodation, AccommodationViewModel>()
                .ForMember(x => x.Price, opt =>
                    opt.MapFrom(x =>
                        x.AdditionalPrice
                        + (x.AccommodationBedTypes.Sum(a => a.BedType.Capacity)
                        * x.AccommodationBedTypes.Sum(a => a.BedType.Price))));
        }
    }
}
