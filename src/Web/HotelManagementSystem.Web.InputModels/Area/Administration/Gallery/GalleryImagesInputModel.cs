namespace HotelManagementSystem.Web.InputModels.Area.Administration.Gallery
{
    using Microsoft.AspNetCore.Http;

    public class GalleryImagesInputModel
    {
        public IEnumerable<IFormFile>? Images { get; set; }
    }
}
