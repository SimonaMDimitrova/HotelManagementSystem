namespace HotelManagementSystem.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using HotelManagementSystem.Web.InputModels.Area.Administration.ManageBookings;

    public interface IBookingsService
    {
        public Task AddAsync(BookingInputModel input);

        public IEnumerable<T> GetAll<T>();

        public T GetById<T>(string id);

        public Task CancelAsync(string id);

        public Task EditAsync(EditBookingViewModel input);
    }
}
