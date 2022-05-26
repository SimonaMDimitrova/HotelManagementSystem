namespace HotelManagementSystem.Data.Seeding
{
    using HotelManagementSystem.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class AboutUsInfoSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.AboutUsPageInfo.Any())
            {
                return;
            }

            var title = "The Royal Hotel";
            var description = "Royal Hotel features a terrace and views of the city. Among the facilities of this property are a restaurant, a 24-hour front desk and room service, along with free WiFi. Free private parking is available and the hotel also provides car hire for guests who want to explore the surrounding area.";

            var image = new Image
            {
                Extension = "jpg",
            };

            await dbContext.AboutUsPageInfo
                .AddAsync(new AboutUsInfo { Title = title, Description = description, Image = image });
        }
    }
}
