namespace HotelManagementSystem.Web.Areas.Administration.Controllers
{
    using HotelManagementSystem.Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = $"{GlobalConstants.AdministratorRoleName},{GlobalConstants.ReceptionistRoleName}")]
    [Area("Administration")]
    public class ReceptionistController : Controller
    {
    }
}
