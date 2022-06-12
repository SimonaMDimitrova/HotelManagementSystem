namespace HotelManagementSystem.Web.InputModels.Area.Administration.ManageContact
{
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;
    using HotelManagementSystem.Data.Models;
    using HotelManagementSystem.Services.Mapping;

    public class ContactInputModel : IMapFrom<Contact>, IHaveCustomMappings
    {
        [Required(ErrorMessage = "Enter valid phone number.")]
        [RegularExpression(@"^\s*(?:\+?(\d{1,3}))?[-. (]*(\d{3})[-. )]*(\d{3})[-. ]*(\d{4})(?: *x(\d+))?\s*$", ErrorMessage = "Enter valid phone number.")]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Enter valid e-mail.")]
        [EmailAddress(ErrorMessage = "Enter valid e-mail.")]
        public string Email { get; set; }

        public int StartOfTheWorkingDayHour { get; set; }

        public int StartOfTheWorkingDayMinutes { get; set; }

        public int EndOfTheWorkingDayHour { get; set; }

        public int EndOfTheWorkingDayMinutes { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Contact, ContactInputModel>()
                .ForMember(x => x.StartOfTheWorkingDayHour, opt =>
                    opt.MapFrom(x => x.StartOfTheWorkingDay.Hours))
                .ForMember(x => x.StartOfTheWorkingDayMinutes, opt =>
                    opt.MapFrom(x => x.StartOfTheWorkingDay.Minutes))
                .ForMember(x => x.EndOfTheWorkingDayHour, opt =>
                    opt.MapFrom(x => x.EndOfTheWorkingDay.Hours))
                .ForMember(x => x.EndOfTheWorkingDayMinutes, opt =>
                    opt.MapFrom(x => x.EndOfTheWorkingDay.Minutes));
        }
    }
}
