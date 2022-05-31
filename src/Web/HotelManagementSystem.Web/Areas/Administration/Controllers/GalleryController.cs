namespace HotelManagementSystem.Web.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class GalleryController : AdministrationController
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
