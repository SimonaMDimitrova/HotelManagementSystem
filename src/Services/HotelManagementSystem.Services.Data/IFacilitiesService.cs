namespace HotelManagementSystem.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using HotelManagementSystem.Web.InputModels.Area.Administration.ManageFacilities;

    public interface IFacilitiesService
    {
        public IEnumerable<T> GetAll<T>();

        public IEnumerable<T> GetAllAvailable<T>();

        public T GetById<T>(string id);

        public Task EditAsync(FacilityInputModel input);

        public string GetName(string id);
    }
}
