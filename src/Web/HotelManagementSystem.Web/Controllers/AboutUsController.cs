using HotelManagementSystem.Services.Data;
using HotelManagementSystem.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.Web.Controllers
{
    public class AboutUsController : BaseController
    {
        private readonly IAboutUsInfoService aboutUsInfoService;

        public AboutUsController(IAboutUsInfoService aboutUsInfoService)
        {
            this.aboutUsInfoService = aboutUsInfoService;
        }

        public IActionResult Index()
        {
            var model = this.aboutUsInfoService.Get<AboutUsInfoViewModel>();

            return this.View(model);
        }
    }
}
