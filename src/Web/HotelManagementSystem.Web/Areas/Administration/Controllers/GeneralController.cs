namespace HotelManagementSystem.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using HotelManagementSystem.Services.Data;
    using HotelManagementSystem.Web.InputModels;
    using Microsoft.AspNetCore.Mvc;

    public class GeneralController : AdministrationController
    {
        private readonly IAboutUsInfoService aboutUsInfoService;

        public GeneralController(IAboutUsInfoService aboutUsInfoService)
        {
            this.aboutUsInfoService = aboutUsInfoService;
        }

        public IActionResult Index()
        {
            var model = this.aboutUsInfoService.Get<AboutUsInfoInputModel>();
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(AboutUsInfoInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.aboutUsInfoService.EditAsync(input);

            return this.RedirectToAction();
        }
    }
}
