namespace HotelManagementSystem.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using HotelManagementSystem.Web.InputModels.Area.Administration.ManageBeds;

    public interface IBedTypesService
    {
        public IEnumerable<T> GetAll<T>();

        public IEnumerable<string> GetAllByAccommodationId(string id);

        public T GetById<T>(string id);

        public string GetNameById(string id);

        public Task EditAsync(BedTypeInputModel input);
    }
}
