namespace HotelManagementSystem.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using HotelManagementSystem.Web.InputModels.Area.Administration.ManageBookings;

    public interface IBookingsService
    {
        public Task AddAsync(BookingInputModel input);
    }
}
