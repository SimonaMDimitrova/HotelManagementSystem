namespace HotelManagementSystem.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using HotelManagementSystem.Web.InputModels.Area.Administration.ManageAccommodations;
    using HotelManagementSystem.Web.InputModels.Area.Administration.ManageBookings;

    public interface IAccommodationsService
    {
        public IEnumerable<T> GetAll<T>();

        public T GetById<T>(string id);

        public Task EditAsync(AccommodationInputModel input);

        public string GetName(string id);

        public IEnumerable<T> GetAvailable<T>(AccommodationSearchInputModel<T> input);
    }
}
