namespace HotelManagementSystem.Web.ViewModels.Bookings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using HotelManagementSystem.Data.Models;
    using HotelManagementSystem.Services.Mapping;

    public class BookingViewModel : IMapFrom<Booking>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string AccommodationName { get; set; }

        public IEnumerable<string> BedTypes { get; set; }

        public IEnumerable<string> Facilities { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public decimal Price { get; set; }

        public int GuestsCount { get; set; }

        public string CheckOut { get; set; }

        public DateTime CheckIn { get; set; }

        public string CheckInString { get; set; }

        public string PID { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Booking, BookingViewModel>()
                .ForMember(x => x.CheckInString, opt =>
                    opt.MapFrom(x => x.CheckIn.ToShortDateString()))
                .ForMember(x => x.CheckOut, opt =>
                    opt.MapFrom(x => x.CheckOut.ToShortDateString()))
                .ForMember(x => x.GuestsCount, opt =>
                    opt.MapFrom(x => x.Accommodation.AccommodationBedTypes.Sum(x => x.BedType.Capacity)))
                .ForMember(x => x.Username, opt =>
                    opt.MapFrom(x => $"{x.FirstName} {x.LastName}"))
                .ForMember(x => x.Facilities, opt =>
                    opt.MapFrom(x => x.BookingFacilities.Select(f => f.Facility.Name).ToList()))
                .ForMember(x => x.BedTypes, opt =>
                    opt.MapFrom(x => x.Accommodation.AccommodationBedTypes.Select(f => f.BedType.Name).ToList()))
                .ForMember(x => x.AccommodationName, opt =>
                    opt.MapFrom(x => x.Accommodation.Name))
                .ForMember(x => x.Email, opt =>
                    opt.MapFrom(x => x.ApplicationUser.Email));
        }
    }
}
