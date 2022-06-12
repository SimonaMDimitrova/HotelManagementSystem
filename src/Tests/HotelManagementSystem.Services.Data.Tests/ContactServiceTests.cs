using Xunit;

[assembly: CollectionBehavior(DisableTestParallelization = true)]

namespace HotelManagementSystem.Services.Data.Tests
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using HotelManagementSystem.Data;
    using HotelManagementSystem.Data.Models;
    using HotelManagementSystem.Web.InputModels.Area.Administration.ManageContact;
    using HotelManagementSystem.Web.ViewModels.Contact;
    using Microsoft.EntityFrameworkCore;

    public class ContactServiceTests
    {
        [Fact]
        public async Task EditAsyncSuccessfully()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "ContactTestDb").Options;
            using var dbContext = new ApplicationDbContext(options);

            var contact = new Contact
            {
                Address = "Some address here",
                Country = "Egypt",
                Email = "hotel@gmail.com",
                PhoneNumber = "088888888",
                EndOfTheWorkingDay = new TimeSpan(5, 10, 0),
                StartOfTheWorkingDay = new TimeSpan(15, 30, 0),
                Town = "Cairo",
            };
            await dbContext.Contact.AddAsync(contact);
            await dbContext.SaveChangesAsync();

            var service = new ContactService(dbContext);

            var toBeEditedModel = new ContactInputModel
            {
                PhoneNumber = "088888881",
                Email = "hotel1@gmail.com",
                EndOfTheWorkingDayHour = 4,
                EndOfTheWorkingDayMinutes = 30,
                StartOfTheWorkingDayHour = 10,
                StartOfTheWorkingDayMinutes = 10,
            };

            await service.EditAsync(toBeEditedModel);
            var actualResult = dbContext.Contact.First();

            Assert.Equal(toBeEditedModel.PhoneNumber, actualResult.PhoneNumber);
        }

        [Fact]
        public async Task GetEmailShouldReturnTheContactEmail()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "ContactTestDb").Options;
            using var dbContext = new ApplicationDbContext(options);

            var contact = new Contact
            {
                Address = "Some address here",
                Country = "Egypt",
                Email = "hotel@gmail.com",
                PhoneNumber = "088888888",
                EndOfTheWorkingDay = new TimeSpan(5, 10, 0),
                StartOfTheWorkingDay = new TimeSpan(15, 30, 0),
                Town = "Cairo",
            };
            await dbContext.Contact.AddAsync(contact);
            await dbContext.SaveChangesAsync();

            var service = new ContactService(dbContext);

            var actualResult = service.GetEmail();
            var expectedResult = "hotel@gmail.com";
            Assert.Equal(expectedResult, actualResult);
        }
    }
}

// [Fact]
// public void GetShouldReturnSingleContactModel()
// {
//     var options = new DbContextOptionsBuilder<ApplicationDbContext>()
//         .UseInMemoryDatabase(databaseName: "ContactTestDb").Options;
//     using var dbContext = new ApplicationDbContext(options);

//     var contact = new Contact
//     {
//         Address = "Some address here",
//         Country = "Egypt",
//         Email = "hotel@gmail.com",
//         PhoneNumber = "088888888",
//         EndOfTheWorkingDay = new TimeSpan(5, 10, 0),
//         StartOfTheWorkingDay = new TimeSpan(15, 30, 0),
//         Town = "Cairo",
//     };
//     dbContext.Contact.Add(contact);
//     dbContext.SaveChanges();

//     var contacts = dbContext.Contact.ToList();

//     var contactService = new ContactService(dbContext);

//     var actualResult = contactService.Get<ContactViewModel>();
//     var expectedResult = new ContactViewModel
//     {
//         Address = "Some address here",
//         Country = "Egypt",
//         Email = "hotel@gmail.com",
//         PhoneNumber = "088888888",
//         EndOfTheWorkingDay = "5:10",
//         StartOfTheWorkingDay = "15:30",
//         Town = "Cairo",
//     };

//     Assert.True(actualResult.Equals(expectedResult));
// }