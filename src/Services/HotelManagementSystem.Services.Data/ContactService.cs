namespace HotelManagementSystem.Services.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using HotelManagementSystem.Data;
    using HotelManagementSystem.Services.Mapping;
    using HotelManagementSystem.Web.InputModels.Area.Administration.ManageContact;

    public class ContactService : IContactService
    {
        private readonly ApplicationDbContext dbContext;

        public ContactService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public T Get<T>()
        {
            var contact = this.dbContext
                .Contact
                .To<T>()
                .First();

            return contact;
        }

        public string GetEmail()
        {
            var email = this.dbContext
                .Contact
                .First()
                .Email;

            return email;
        }

        public async Task EditAsync(ContactInputModel input)
        {
            var contact = this.dbContext
                .Contact
                .First();

            contact.Address = input.Address;
            contact.Email = input.Email;
            contact.Country = input.Country;
            contact.Town = input.Town;
            contact.PhoneNumber = input.PhoneNumber;
            contact.StartOfTheWorkingDay = new TimeSpan(input.StartOfTheWorkingDayHour, input.StartOfTheWorkingDayMinutes, 0);
            contact.EndOfTheWorkingDay = new TimeSpan(input.EndOfTheWorkingDayHour, input.EndOfTheWorkingDayMinutes, 0);

            await this.dbContext.SaveChangesAsync();
        }
    }
}
