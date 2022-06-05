namespace HotelManagementSystem.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using HotelManagementSystem.Data;
    using HotelManagementSystem.Services.Mapping;
    using HotelManagementSystem.Web.InputModels.Area.Administration.ManageAccommodations;

    public class AccommodationsService : IAccommodationsService
    {
        private readonly ApplicationDbContext dbContext;

        public AccommodationsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<T> GetAll<T>()
        {
            var accommodations = this.dbContext
                .Accommodations
                .OrderByDescending(x => x.AdditionalPrice
                    + x.AccommodationBedTypes.Sum(a => a.BedType.Price))
                .To<T>()
                .ToList();
            return accommodations;
        }

        public T GetById<T>(string id)
        {
            var accommodation = this.dbContext
                .Accommodations
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefault();

            return accommodation;
        }

        public async Task EditAsync(AccommodationInputModel input)
        {
            var accommodation = this.dbContext
                .Accommodations
                .FirstOrDefault(x => x.Id == input.Id);

            if (accommodation == null)
            {
                throw new NullReferenceException();
            }

            accommodation.Description = input.Description;
            accommodation.AdditionalPrice = input.AdditionalPrice;

            await this.dbContext.SaveChangesAsync();
        }

        public string GetName(string id)
        {
            var accommodationName = this.dbContext
                .Accommodations
                .FirstOrDefault(x => x.Id == id);

            return accommodationName.Name;
        }
    }
}
