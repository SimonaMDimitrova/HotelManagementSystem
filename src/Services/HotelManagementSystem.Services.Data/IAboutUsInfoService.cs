namespace HotelManagementSystem.Services.Data
{
    using HotelManagementSystem.Web.InputModels;
    using System.Threading.Tasks;

    public interface IAboutUsInfoService
    {
        public T Get<T>();

        public Task EditAsync(AboutUsInfoInputModel input);
    }
}
