namespace HotelManagementSystem.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using HotelManagementSystem.Services.Data;
    using HotelManagementSystem.Web.InputModels.Area.Administration.General;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;

    public class GeneralController : AdministrationController
    {
        private readonly IAboutUsInfoService aboutUsInfoService;
        private readonly IWebHostEnvironment environment;

        public GeneralController(
            IAboutUsInfoService aboutUsInfoService,
            IWebHostEnvironment environment)
        {
            this.aboutUsInfoService = aboutUsInfoService;
            this.environment = environment;
        }

        public IActionResult Index()
        {
            var model = this.aboutUsInfoService.Get<AboutUsInfoInputModel>();
            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Index(AboutUsInfoInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.ImageUrl = this.aboutUsInfoService.GetImageUrl();
                return this.View(input);
            }

            await this.aboutUsInfoService.EditAsync(input, $"{this.environment.WebRootPath}/general/image/about-us");

            return this.RedirectToAction();
        }
    }
}
