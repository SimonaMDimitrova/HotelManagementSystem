namespace HotelManagementSystem.Data.Models
{
    using System;

    using HotelManagementSystem.Data.Common.Models;

    public class Contact : BaseModel<string>
    {
        public Contact()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Country { get; set; }

        public string Town { get; set; }

        public string Address { get; set; }

        public TimeSpan StartOfTheWorkingDay { get; set; }

        public TimeSpan EndOfTheWorkingDay { get; set; }
    }
}
