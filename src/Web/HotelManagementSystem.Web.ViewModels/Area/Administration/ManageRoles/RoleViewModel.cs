namespace HotelManagementSystem.Web.ViewModels.Area.Administration.ManageRoles
{
    using System.Collections.Generic;

    public class RoleViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Users { get; set; }
    }
}
