namespace HotelManagementSystem.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using HotelManagementSystem.Data;
    using HotelManagementSystem.Data.Models;
    using HotelManagementSystem.Web.InputModels.Area.Administration.ManageBookings;

    public class BookingsService : IBookingsService
    {
        private readonly ApplicationDbContext dbContext;

        public BookingsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddAsync(BookingInputModel input)
        {
            var booking = new Booking
            {
                AccommodationId = input.AccommodationId,
                CheckIn = input.CheckIn,
                CheckOut = input.CheckOut,
                FirstName = input.FirstName,
                LastName = input.LastName,
                PhoneNumber = input.PhoneNumber,
            };

            foreach (var facilityId in input.FacilitiesIds)
            {
                booking.BookingFacilities.Add(
                    new BookingFacility
                    {
                        BookingId = booking.Id,
                        FacilityId = facilityId,
                    });
            }

            await this.dbContext.AddAsync(booking);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
