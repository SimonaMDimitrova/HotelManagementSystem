namespace HotelManagementSystem.Web.ViewModels.ViewComponents.Accommodations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using AutoMapper;
    using HotelManagementSystem.Data.Models;
    using HotelManagementSystem.Services.Mapping;

    public class AccommodationViewModel : IMapFrom<Accommodation>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public decimal PricePerNight { get; set; }

        public int GuestsCount { get; set; }

        public string ImageName { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Accommodation, AccommodationViewModel>()
                .ForMember(x => x.GuestsCount, opt =>
                    opt.MapFrom(x => x.AccommodationBedTypes.Sum(a => a.BedType.Capacity)))
                .ForMember(x => x.PricePerNight, opt =>
                    opt.MapFrom(x => x.AdditionalPrice
                        + x.AccommodationBedTypes.Sum(a => a.BedType.Price)));
        }
    }
}
