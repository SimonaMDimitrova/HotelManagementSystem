namespace HotelManagementSystem.Web.Controllers
{
    using HotelManagementSystem.Services;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;

    public class GalleryController : BaseController
    {
        private readonly IImagesService imagesService;
        private readonly IWebHostEnvironment environment;

        public GalleryController(
            IImagesService imagesService,
            IWebHostEnvironment environment)
        {
            this.imagesService = imagesService;
            this.environment = environment;
        }

        public IActionResult Index()
        {
            this.ViewData["IsUserOnHomePage"] = false;

            var viewModel = this.imagesService.GetAll($"{this.environment.WebRootPath}/general/image/gallery");
            return this.View(viewModel);
        }
    }
}
