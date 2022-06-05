namespace HotelManagementSystem.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using HotelManagementSystem.Web.InputModels.Area.Administration.Gallery;

    public interface IImagesService
    {
        public IEnumerable<string> GetAll(string path);

        public Task AddAllAsync(GalleryImagesInputModel input, string path);

        public void Delete(string path);
    }
}
