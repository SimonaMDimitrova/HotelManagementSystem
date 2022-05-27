namespace HotelManagementSystem.Services.Data
{
    using System.Threading.Tasks;

    using HotelManagementSystem.Web.InputModels.Area.Administration.General;

    public interface IAboutUsInfoService
    {
        public T Get<T>();

        public Task EditAsync(AboutUsInfoInputModel input, string imagePath);

        public string GetImageUrl();
    }
}
