namespace HotelManagementSystem.Web.Controllers
{
    using HotelManagementSystem.Services.Data;
    using HotelManagementSystem.Web.ViewModels.AboutUs;
    using Microsoft.AspNetCore.Mvc;

    public class AboutUsController : BaseController
    {
        private readonly IAboutUsInfoService aboutUsInfoService;

        public AboutUsController(IAboutUsInfoService aboutUsInfoService)
        {
            this.aboutUsInfoService = aboutUsInfoService;
        }

        public IActionResult Index()
        {
            this.ViewData["IsUserOnHomePage"] = false;

            var model = this.aboutUsInfoService.Get<AboutUsInfoViewModel>();

            return this.View(model);
        }
    }
}
