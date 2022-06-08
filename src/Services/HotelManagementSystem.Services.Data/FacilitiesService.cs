namespace HotelManagementSystem.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using HotelManagementSystem.Data;
    using HotelManagementSystem.Data.Models;
    using HotelManagementSystem.Services.Mapping;
    using HotelManagementSystem.Web.InputModels.Area.Administration.ManageFacilities;

    public class FacilitiesService : IFacilitiesService
    {
        private readonly ApplicationDbContext dbContext;

        public FacilitiesService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<T> GetAll<T>()
        {
            var facilities = this.dbContext
                .Facilities
                .OrderBy(x => x.PricePerDay)
                .To<T>()
                .ToList();

            return facilities;
        }

        public T GetById<T>(string id)
        {
            var facility = this.dbContext
                .Facilities
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefault();

            return facility;
        }

        public async Task EditAsync(FacilityInputModel input)
        {
            var facility = this.dbContext
                .Facilities
                .FirstOrDefault(x => x.Id == input.Id);
            if (facility == null)
            {
                throw new NullReferenceException("Facility not found.");
            }

            facility.PricePerDay = input.PricePerDay;
            facility.IsAvailable = input.IsAvailable;

            await this.dbContext.SaveChangesAsync();
        }

        public string GetName(string id)
        {
            var facilityName = this.dbContext
                .Facilities
                .FirstOrDefault(x => x.Id == id)
                ?.Name;

            return facilityName;
        }
    }
}
