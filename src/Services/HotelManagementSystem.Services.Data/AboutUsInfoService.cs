namespace HotelManagementSystem.Services.Data
{
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using HotelManagementSystem.Data;
    using HotelManagementSystem.Services.Mapping;
    using HotelManagementSystem.Web.InputModels.Area.Administration.General;

    public class AboutUsInfoService : IAboutUsInfoService
    {
        private readonly ApplicationDbContext dbContext;

        public AboutUsInfoService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public T Get<T>()
        {
            var aboutUsInfo = this.dbContext
                .AboutUsPageInfo
                .To<T>()
                .First();

            return aboutUsInfo;
        }

        public async Task EditAsync(AboutUsInfoInputModel input, string imagePath)
        {
            var aboutUsInfoEdited = this.dbContext
                .AboutUsPageInfo
                .First();
            aboutUsInfoEdited.Title = input.Title;
            aboutUsInfoEdited.Description = input.Description;

            if (input.Image != null)
            {
                var image = input.Image;
                var extension = Path.GetExtension(image.FileName).TrimStart('.');
                var physicalPath = $"{imagePath}/{aboutUsInfoEdited.Image}";
                using Stream fileStream = new FileStream(physicalPath, FileMode.Create);
                await image.CopyToAsync(fileStream);
            }

            await this.dbContext.SaveChangesAsync();
        }

        public string GetImageUrl()
        {
            var imageUrl = this.dbContext
                .AboutUsPageInfo
                .Select(x => $"/general/image/about-us/{x.Image}")
                .First();

            return imageUrl;
        }
    }
}
