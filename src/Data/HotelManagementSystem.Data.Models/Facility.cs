using HotelManagementSystem.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Data.Models
{
    public class Facility : BaseModel<string>
    {
        public Facility()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public string FavIconCode { get; set; }

        public decimal PricePerDay { get; set; }

        public bool IsAvailable { get; set; }
    }
}
