namespace HotelManagementSystem.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using HotelManagementSystem.Data.Models;

    public class ContactSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Contact.Any())
            {
                return;
            }

            var contact = new Contact
            {
                Address = "Khaled Ibn Al Walid, Gazirat Al Awameyah",
                Email = "some.demo.mail123@gmail.com",
                PhoneNumber = "+35988888888",
                Town = "Luxor",
                Country = "Egypt",
                StartOfTheWorkingDay = new TimeSpan(8, 30, 0),
                EndOfTheWorkingDay = new TimeSpan(19, 30, 0),
            };

            await dbContext.Contact.AddAsync(contact);
        }
    }
}
