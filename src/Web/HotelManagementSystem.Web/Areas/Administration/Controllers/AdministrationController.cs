namespace HotelManagementSystem.Web.Areas.Administration.Controllers
{
    using HotelManagementSystem.Common;
    using HotelManagementSystem.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
