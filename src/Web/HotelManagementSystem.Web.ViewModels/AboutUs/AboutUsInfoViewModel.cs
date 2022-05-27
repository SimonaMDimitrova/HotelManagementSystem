namespace HotelManagementSystem.Web.ViewModels.AboutUs
{
    using AutoMapper;
    using HotelManagementSystem.Data.Models;
    using HotelManagementSystem.Services.Mapping;

    public class AboutUsInfoViewModel : IMapFrom<AboutUsInfo>, IHaveCustomMappings
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<AboutUsInfo, AboutUsInfoViewModel>()
                .ForMember(x => x.ImageUrl, opt =>
                    opt.MapFrom(x =>
                        $"/general/image/about-us/{x.Image.Id}.{x.Image.Extension}"));
        }
    }
}
