namespace HotelManagementSystem.Web.ViewModels.Area.Administration.ManageAccommodations
{
    using AutoMapper;
    using HotelManagementSystem.Data.Models;
    using HotelManagementSystem.Services.Mapping;
    using System.Linq;

    public class AccommodationViewModel : IMapFrom<Accommodation>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public decimal AdditionalPrice { get; set; }

        public int Count { get; set; }

        public string Description { get; set; }

        public string ImageName { get; set; }

        public int GuestsCount { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Accommodation, AccommodationViewModel>()
                .ForMember(x => x.GuestsCount, opt =>
                    opt.MapFrom(x => x.AccommodationBedTypes.Sum(a => a.BedType.Capacity)));
        }
    }
}
