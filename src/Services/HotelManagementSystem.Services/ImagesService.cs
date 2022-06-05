namespace HotelManagementSystem.Services
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using HotelManagementSystem.Web.InputModels.Area.Administration.Gallery;

    public class ImagesService : IImagesService
    {
        public IEnumerable<string> GetAll(string path)
        {
            var directory = new DirectoryInfo(path);
            var images = directory.GetFiles()
                .Select(x => x.Name)
                .ToArray();

            return images;
        }

        public async Task AddAllAsync(GalleryImagesInputModel input, string path)
        {
            if (input.Images.Count() == 0 || input == null)
            {
                throw new NullReferenceException("You should choose any images.");
            }

            var directory = new DirectoryInfo(path);
            foreach (var image in input.Images)
            {
                var extension = Path.GetExtension(image.FileName).TrimStart('.');
                var imageName = Guid.NewGuid().ToString();
                var physicalPath = $"{path}/{imageName}.{extension}";
                using Stream fileStream = new FileStream(physicalPath, FileMode.Create);
                await image.CopyToAsync(fileStream);
            }
        }

        public void Delete(string path)
        {
            File.Delete(path);
        }
    }
}
