namespace HotelManagementSystem.Web.InputModels.Area.Administration.General
{
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;
    using HotelManagementSystem.Data.Models;
    using HotelManagementSystem.Services.Mapping;
    using Microsoft.AspNetCore.Http;

    public class AboutUsInfoInputModel : IMapFrom<AboutUsInfo>, IHaveCustomMappings
    {
        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        public string? ImageUrl { get; set; }

        public IFormFile Image { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<AboutUsInfo, AboutUsInfoInputModel>()
                .ForMember(x => x.ImageUrl, opt =>
                    opt.MapFrom(x =>
                        $"/general/image/about-us/{x.Image.Id}.{x.Image.Extension}"))
                .ForMember(x => x.Image, opt => opt.Ignore());
        }
    }
}
