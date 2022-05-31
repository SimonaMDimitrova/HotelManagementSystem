namespace HotelManagementSystem.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using HotelManagementSystem.Data.Models;

    public class FacilitiesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Facilities.Any())
            {
                return;
            }

            await dbContext.Facilities.AddAsync(new Facility { Name = "Restaurant", Description = "The restaurant offers menus for Lunch and Dinner. The restaurant has a Latin atmosphere with Latin American ornaments and music.", IsAvailable = true, PricePerDay = 40, FavIconCode = "lnr lnr-dinner" });
            await dbContext.Facilities.AddAsync(new Facility { Name = "Sports Club", Description = "A club's focus may be recreational, instructional, competitive, or a combination of these types of activities based on its constitution.", IsAvailable = true, PricePerDay = 0, FavIconCode = "lnr lnr-bicycle" });
            await dbContext.Facilities.AddAsync(new Facility { Name = "Swimming Pool", Description = "Pools are used for other bathing activities, such as playing, wading, water exercising, floating on inner tubes, or cooling off on hot days.", IsAvailable = true, PricePerDay = 0, FavIconCode = "lnr lnr-shirt" });
            await dbContext.Facilities.AddAsync(new Facility { Name = "Rent a Car", Description = "Rent a car whenever you need it.", IsAvailable = true, PricePerDay = 30, FavIconCode = "lnr lnr-car" });
            await dbContext.Facilities.AddAsync(new Facility { Name = "Spa", Description = "Relax right now!", IsAvailable = true, PricePerDay = 10, FavIconCode = "lnr lnr-construction" });
            await dbContext.Facilities.AddAsync(new Facility { Name = "Bar", Description = "Need a drink? Get one!", IsAvailable = true, PricePerDay = 40, FavIconCode = "lnr lnr-coffee-cup" });

            await dbContext.SaveChangesAsync();
        }
    }
}
