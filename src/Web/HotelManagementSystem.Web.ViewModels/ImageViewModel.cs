namespace HotelManagementSystem.Web.ViewModels
{
    using HotelManagementSystem.Data.Models;
    using HotelManagementSystem.Services.Mapping;

    public class ImageViewModel : IMapFrom<Image>
    {
        public string Id { get; set; }

        public string Extension { get; set; }
    }
}