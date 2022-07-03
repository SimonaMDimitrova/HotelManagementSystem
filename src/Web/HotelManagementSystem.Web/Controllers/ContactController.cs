namespace HotelManagementSystem.Web.Controllers
{
    using HotelManagementSystem.Services.Data;
    using HotelManagementSystem.Web.InputModels.Contact;
    using HotelManagementSystem.Web.ViewModels.Contact;
    using Microsoft.AspNetCore.Mvc;

    public class ContactController : BaseController
    {
        private readonly IContactService contactService;

        public ContactController(
            IContactService contactService)
        {
            this.contactService = contactService;
        }

        public IActionResult Index()
        {
            this.ViewData["IsUserOnHomePage"] = false;

            var viewModel = this.contactService.Get<ContactViewModel>();

            return this.View(viewModel);
        }
    }
}
