namespace HotelManagementSystem.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;
    using HotelManagementSystem.Data;
    using HotelManagementSystem.Services.Mapping;
    using HotelManagementSystem.Web.InputModels;

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

        public async Task EditAsync(AboutUsInfoInputModel input)
        {
            var aboutUsInfoEdited = this.dbContext
                .AboutUsPageInfo
                .First();
            aboutUsInfoEdited.Title = input.Title;
            aboutUsInfoEdited.Description = input.Description;

            await this.dbContext.SaveChangesAsync();
        }
    }
}
