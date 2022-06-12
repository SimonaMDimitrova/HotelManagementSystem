namespace HotelManagementSystem.Web.InputModels.Area.Administration.General
{
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;
    using HotelManagementSystem.Data.Models;
    using HotelManagementSystem.Services.Mapping;
    using Microsoft.AspNetCore.Http;

    public class AboutUsInfoInputModel : IMapFrom<AboutUsInfo>, IHaveCustomMappings
    {
        [Required(ErrorMessage = "You must add hotel name!")]
        [MinLength(5, ErrorMessage = "Your hotel name must be at least 5 letters length.")]
        [MaxLength(100, ErrorMessage = "Your hotel name must not be more than 100 letters length.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "You must add description.")]
        [MaxLength(1000, ErrorMessage = "Description must not be more than 1000 leters length.")]
        public string Description { get; set; }

        public string? ImageUrl { get; set; }

        public IFormFile? Image { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<AboutUsInfo, AboutUsInfoInputModel>()
                .ForMember(x => x.ImageUrl, opt =>
                    opt.MapFrom(x =>
                        $"/general/image/about-us/{x.Image}"))
                .ForMember(x => x.Image, opt => opt.Ignore());
        }
    }
}
