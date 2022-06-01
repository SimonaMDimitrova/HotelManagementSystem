namespace HotelManagementSystem.Web.Areas.Administration.Controllers
{
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using HotelManagementSystem.Services;
    using HotelManagementSystem.Web.InputModels.Area.Administration.Gallery;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;

    public class GalleryController : AdministrationController
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
            var viewModel = this.imagesService.GetAll($"{this.environment.WebRootPath}/general/image/gallery");
            return this.View(viewModel);
        }

        public IActionResult Add()
        {
            var viewModel = new GalleryImagesInputModel();
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(GalleryImagesInputModel input)
        {
            try
            {
                var path = $"{this.environment.WebRootPath}/general/image/gallery";
                await this.imagesService.AddAllAsync(input, path);
            }
            catch (System.Exception)
            {
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.RedirectToAction(nameof(this.Index));
        }

        [HttpPost]
        public IActionResult Delete(string id)
        {
            var path = $"{this.environment.WebRootPath}/general/image/gallery/{id}";
            this.imagesService.Delete(path);

            return this.RedirectToAction(nameof(this.Index));
        }
    }
}
