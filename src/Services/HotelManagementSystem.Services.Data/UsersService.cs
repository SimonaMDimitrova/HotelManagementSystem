namespace HotelManagementSystem.Services.Data
{
    using System.Linq;

    using HotelManagementSystem.Data;
    using HotelManagementSystem.Web.InputModels.Bookings;

    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext dbContext;

        public UsersService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public UserInfoInputModel GetPreviousResults(string username)
        {
            var user = this.dbContext
                .Users
                .FirstOrDefault(x => x.Email == username);
            var booking = this.dbContext
                .Bookings
                .OrderBy(x => x.CreatedOn)
                .FirstOrDefault(x => x.ApplicationUserId == user.Id);

            if (booking == null)
            {
                return null;
            }

            var userInfo = new UserInfoInputModel
            {
                FirstName = booking.FirstName,
                LastName = booking.LastName,
                PhoneNumber = booking.PhoneNumber,
                Username = username,
                PID = booking.PID,
            };

            return userInfo;
        }
    }
}
