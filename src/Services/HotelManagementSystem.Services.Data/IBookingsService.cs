namespace HotelManagementSystem.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using HotelManagementSystem.Web.InputModels.Area.Administration.ManageBookings;

    public interface IBookingsService
    {
        public Task AddWithoutUserAsync(BookingInputModel input);

        public Task AddWithUserAsync(HotelManagementSystem.Web.InputModels.Bookings.BookingInputModel input);

        public IEnumerable<T> GetAll<T>();

        public IEnumerable<T> GetAllActive<T>();

        public IEnumerable<T> GetAllPast<T>();

        public IEnumerable<T> GetAllCanceled<T>();

        public T GetById<T>(string id);

        public Task CancelAsync(string id);

        public BookingStatusInputModel GetStatus(string id);

        public Task EditAsync(BookingStatusInputModel input);

        public IEnumerable<T> GetByUserId<T>(string username);
    }
}
