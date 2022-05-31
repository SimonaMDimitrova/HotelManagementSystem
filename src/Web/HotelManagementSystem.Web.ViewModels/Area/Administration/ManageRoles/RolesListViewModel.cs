namespace HotelManagementSystem.Web.ViewModels.Area.Administration.ManageRoles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RolesListViewModel
    {
        public ICollection<RoleViewModel> Roles { get; set; }
    }
}
