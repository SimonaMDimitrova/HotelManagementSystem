namespace HotelManagementSystem.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using HotelManagementSystem.Data.Models;

    public class BedTypesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.BedTypes.Any())
            {
                return;
            }

            await dbContext.BedTypes.AddAsync(new BedType { Name = "Single bed", Capacity = 1, Price = 15 });
            await dbContext.BedTypes.AddAsync(new BedType { Name = "Double bed", Capacity = 2, Price = 40 });
            await dbContext.BedTypes.AddAsync(new BedType { Name = "Double coach", Capacity = 2, Price = 35 });
            await dbContext.BedTypes.AddAsync(new BedType { Name = "Single coach", Capacity = 1, Price = 10 });
        }
    }
}