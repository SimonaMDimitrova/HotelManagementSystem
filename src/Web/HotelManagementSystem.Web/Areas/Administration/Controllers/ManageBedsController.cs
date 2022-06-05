namespace HotelManagementSystem.Web.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class ManageBedsController : AdministrationController
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
