namespace HotelManagementSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class AccommodationsController : BaseController
    {
        public IActionResult Index()
        {
            this.ViewData["IsUserOnHomePage"] = false;

            return this.View();
        }
    }
}
