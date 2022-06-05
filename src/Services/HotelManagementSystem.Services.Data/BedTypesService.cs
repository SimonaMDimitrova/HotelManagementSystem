namespace HotelManagementSystem.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using HotelManagementSystem.Data;
    using HotelManagementSystem.Services.Mapping;
    using HotelManagementSystem.Web.InputModels.Area.Administration.ManageBeds;

    public class BedTypesService : IBedTypesService
    {
        private readonly ApplicationDbContext dbContext;

        public BedTypesService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<T> GetAll<T>()
        {
            var beds = this.dbContext
                .BedTypes
                .OrderByDescending(x => x.Price)
                .To<T>()
                .ToList();

            return beds;
        }

        public T GetById<T>(string id)
        {
            var bed = this.dbContext
                .BedTypes
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefault();
            return bed;
        }

        public string GetNameById(string id)
        {
            var bedName = this.dbContext
                .BedTypes
                .FirstOrDefault(x => x.Id == id).Name;

            return bedName;
        }

        public async Task EditAsync(BedTypeInputModel input)
        {
            var bed = this.dbContext
                .BedTypes
                .FirstOrDefault(x => x.Id == input.Id);

            if (bed == null)
            {
                throw new NullReferenceException();
            }

            bed.Price = input.Price;

            await this.dbContext.SaveChangesAsync();
        }
    }
}
