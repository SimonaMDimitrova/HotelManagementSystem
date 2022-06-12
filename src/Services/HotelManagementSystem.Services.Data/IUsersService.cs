namespace HotelManagementSystem.Services.Data
{
    using HotelManagementSystem.Web.InputModels.Bookings;

    public interface IUsersService
    {
        public UserInfoInputModel GetPreviousResults(string username);
    }
}
