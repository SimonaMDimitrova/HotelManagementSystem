namespace HotelManagementSystem.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using HotelManagementSystem.Data;
    using HotelManagementSystem.Data.Models;
    using HotelManagementSystem.Services.Mapping;
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

        public async Task CancelAsync(string id)
        {
            var booking = this.dbContext
                .Bookings
                .FirstOrDefault(x => x.Id == id);

            booking.DeletedOn = DateTime.UtcNow;
            booking.IsDeleted = true;
            booking.ModifiedOn = DateTime.UtcNow;
            await this.dbContext.SaveChangesAsync();
        }

        public async Task EditAsync(EditBookingViewModel input)
        {
            var booking = this.dbContext
                .Bookings
                .FirstOrDefault(x => x.Id == input.Id);

            booking.CheckIn = input.CheckIn;
            booking.CheckOut = input.CheckOut;
            await this.dbContext.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>()
        {
            var bookings = this.dbContext
                .Bookings
                .Where(x => x.IsDeleted != true && x.CheckIn > DateTime.UtcNow.AddDays(5))
                .OrderBy(x => x.CreatedOn)
                .To<T>()
                .ToList();

            return bookings;
        }

        public T GetById<T>(string id)
        {
            var booking = this.dbContext
                .Bookings
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefault();

            return booking;
        }
    }
}
