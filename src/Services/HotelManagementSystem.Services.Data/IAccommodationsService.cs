namespace HotelManagementSystem.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using HotelManagementSystem.Web.InputModels.Area.Administration.ManageAccommodations;

    public interface IAccommodationsService
    {
        public IEnumerable<T> GetAll<T>();

        public T GetById<T>(string id);

        public Task EditAsync(AccommodationInputModel input);

        public string GetName(string id);
    }
}
