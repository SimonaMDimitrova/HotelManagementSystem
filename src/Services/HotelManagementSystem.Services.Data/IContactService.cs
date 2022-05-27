namespace HotelManagementSystem.Services.Data
{
    using System.Threading.Tasks;

    using HotelManagementSystem.Web.InputModels.Area.Administration.ManageContact;

    public interface IContactService
    {
        public T Get<T>();

        public string GetEmail();

        public Task EditAsync(ContactInputModel input);
    }
}
