namespace HotelManagementSystem.Data.Models
{
    using System;

    using HotelManagementSystem.Data.Common.Models;

    public class AboutUsInfo : BaseModel<string>
    {
        public AboutUsInfo()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Title { get; set; }

        public string Description { get; set; }

        public virtual Image Image { get; set; }

        public string ImageId { get; set; }
    }
}
