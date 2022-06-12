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
    using Microsoft.EntityFrameworkCore;

    public class BookingsService : IBookingsService
    {
        private readonly ApplicationDbContext dbContext;

        public BookingsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddWithoutUserAsync(BookingInputModel input)
        {
            var booking = new Booking
            {
                AccommodationId = input.AccommodationId,
                CheckIn = input.CheckIn,
                CheckOut = input.CheckOut,
                FirstName = input.FirstName,
                LastName = input.LastName,
                PhoneNumber = input.PhoneNumber,
                IsPaid = input.IsPaid,
                PID = input.PID,
                Price = input.Price,
                CreatedOn = DateTime.UtcNow,
            };

            var freeFacilities = this.dbContext
                .Facilities
                .Where(x => x.PricePerDay == 0)
                .Select(x => x.Id)
                .ToList();
            for (int i = 0; i < freeFacilities.Count; i++)
            {
                var currentFacilityId = freeFacilities[i];
                booking.BookingFacilities.Add(
                    new BookingFacility
                    {
                        BookingId = booking.Id,
                        FacilityId = currentFacilityId,
                    });
            }

            if (input.FacilitiesIds != null && input.FacilitiesIds.Count() > 0)
            {
                foreach (var facilityId in input.FacilitiesIds)
                {
                    booking.BookingFacilities.Add(
                        new BookingFacility
                        {
                            BookingId = booking.Id,
                            FacilityId = facilityId,
                        });

                    var currentFacilityPrice = this.dbContext
                        .Facilities
                        .FirstOrDefault(x => x.Id == facilityId).PricePerDay;

                    booking.Price += currentFacilityPrice * (decimal)(input.CheckOut - input.CheckIn).TotalDays;
                }
            }

            await this.dbContext.AddAsync(booking);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task AddWithUserAsync(Web.InputModels.Bookings.BookingInputModel input)
        {
            var userId = this.dbContext
                .Users.FirstOrDefault(x => x.Email == input.User.Username).Id;
            var booking = new Booking
            {
                AccommodationId = input.AccommodationId,
                CheckIn = input.CheckIn,
                CheckOut = input.CheckOut,
                FirstName = input.User.FirstName,
                LastName = input.User.LastName,
                PhoneNumber = input.User.PhoneNumber,
                IsPaid = input.IsPaid,
                PID = input.User.PID,
                Price = input.Price,
                CreatedOn = DateTime.UtcNow,
                ApplicationUserId = userId,
            };

            var freeFacilities = this.dbContext
                .Facilities
                .Where(x => x.PricePerDay == 0)
                .Select(x => x.Id)
                .ToList();
            for (int i = 0; i < freeFacilities.Count; i++)
            {
                var currentFacilityId = freeFacilities[i];
                booking.BookingFacilities.Add(
                    new BookingFacility
                    {
                        BookingId = booking.Id,
                        FacilityId = currentFacilityId,
                    });
            }

            if (input.FacilitiesIds != null && input.FacilitiesIds.Count() > 0)
            {
                foreach (var facilityId in input.FacilitiesIds)
                {
                    booking.BookingFacilities.Add(
                        new BookingFacility
                        {
                            BookingId = booking.Id,
                            FacilityId = facilityId,
                        });

                    var currentFacilityPrice = this.dbContext
                        .Facilities
                        .FirstOrDefault(x => x.Id == facilityId).PricePerDay;

                    booking.Price += currentFacilityPrice * (decimal)(input.CheckOut - input.CheckIn).TotalDays;
                }
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

        public async Task EditAsync(BookingStatusInputModel input)
        {
            var booking = this.dbContext
                .Bookings
                .FirstOrDefault(x => x.Id == input.Id);

            if (booking.ActualCheckIn == null && input.CheckIn?.Date != DateTime.UtcNow.Date)
            {
                throw new ArgumentException("Invalid date!");
            }

            booking.ActualCheckIn = booking.ActualCheckIn != null ? booking.ActualCheckIn : input.CheckIn;

            if (booking.ActualCheckIn != null && (input.CheckOut != null && input.CheckOut?.Date != DateTime.UtcNow.Date))
            {
                throw new ArgumentException("Invalid date!");
            }

            booking.ActualCheckOut = input.CheckOut;
            booking.IsPaid = input.IsPaid;
            booking.ModifiedOn = DateTime.UtcNow;

            if (input.CheckIn is not null && input.CheckOut is not null && booking.IsPaid == true)
            {
                booking.IsDeleted = true;
            }

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

        public IEnumerable<T> GetAllActive<T>()
        {
            var bookings = this.dbContext
                .Bookings
                .Where(x => x.IsDeleted == false
                    && x.CheckOut.Date >= DateTime.UtcNow.Date
                    && (x.ActualCheckIn != null || (x.ActualCheckIn == null && x.CheckIn >= DateTime.UtcNow.Date)))
                .OrderBy(x => x.CheckIn)
                .ThenBy(x => x.CreatedOn)
                .To<T>()
                .ToList();

            return bookings;
        }

        public IEnumerable<T> GetAllCanceled<T>()
        {
            var bookings = this.dbContext
                .Bookings
                .IgnoreQueryFilters()
                .Where(x => (x.IsDeleted == true && (x.ActualCheckIn == null || x.ActualCheckOut == null || x.IsPaid == false))
                    || (x.IsDeleted == false && (x.CheckIn.Date < DateTime.UtcNow.Date && x.ActualCheckIn == null)))
                .OrderByDescending(x => x.CheckIn)
                .ThenByDescending(x => x.ModifiedOn)
                .To<T>()
                .ToList();

            return bookings;
        }

        public IEnumerable<T> GetAllPast<T>()
        {
            var bookings = this.dbContext
                .Bookings
                .IgnoreQueryFilters()
                .Where(x => x.IsDeleted == true
                    && x.ActualCheckIn != null
                    && x.ActualCheckOut != null
                    && x.IsPaid == true)
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

        public IEnumerable<T> GetByUserId<T>(string username)
        {
            var userId = this.dbContext
                .Users
                .FirstOrDefault(x => x.Email == username)
                .Id;

            var bookings = this.dbContext
                .Bookings
                .Where(x => x.ApplicationUserId == userId)
                .OrderBy(x => x.CheckIn)
                .To<T>()
                .ToList();

            return bookings;
        }

        public BookingStatusInputModel GetStatus(string id)
        {
            var booking = this.dbContext
                .Bookings
                .FirstOrDefault(x => x.Id == id);
            var status = new BookingStatusInputModel
            {
                CheckIn = booking.ActualCheckIn,
                CheckOut = booking.ActualCheckOut,
                IsPaid = booking.IsPaid,
            };

            return status;
        }
    }
}
