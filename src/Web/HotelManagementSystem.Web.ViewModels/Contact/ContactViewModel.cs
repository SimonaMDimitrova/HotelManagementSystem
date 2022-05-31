namespace HotelManagementSystem.Web.ViewModels.Contact
{
    using System;

    using AutoMapper;
    using HotelManagementSystem.Data.Models;
    using HotelManagementSystem.Services.Mapping;

    public class ContactViewModel : IMapFrom<Contact>, IHaveCustomMappings
    {
        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Country { get; set; }

        public string Town { get; set; }

        public string Address { get; set; }

        public string StartOfTheWorkingDay { get; set; }

        public string EndOfTheWorkingDay { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Contact, ContactViewModel>()
                .ForMember(x => x.StartOfTheWorkingDay, opt =>
                    opt.MapFrom(x =>
                        $"{x.StartOfTheWorkingDay.Hours}:{x.StartOfTheWorkingDay.Minutes}"))
                .ForMember(x => x.EndOfTheWorkingDay, opt =>
                    opt.MapFrom(x =>
                        $"{x.EndOfTheWorkingDay.Hours}:{x.EndOfTheWorkingDay.Minutes}"));
        }
    }
}
