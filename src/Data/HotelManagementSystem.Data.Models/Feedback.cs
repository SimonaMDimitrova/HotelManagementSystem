namespace HotelManagementSystem.Data.Models
{
    using System;

    using HotelManagementSystem.Data.Common.Models;

    public class Feedback : BaseDeletableModel<string>
    {
        public Feedback()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Message { get; set; }

        public string Rate { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public string ApplicationUserId { get; set; }
    }
}
