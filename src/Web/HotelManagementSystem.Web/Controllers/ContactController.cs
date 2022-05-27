namespace HotelManagementSystem.Web.Controllers
{
    using HotelManagementSystem.Services.Data;
    using HotelManagementSystem.Services.Messaging;
    using HotelManagementSystem.Web.InputModels.Contact;
    using HotelManagementSystem.Web.ViewModels.Contact;
    using Microsoft.AspNetCore.Mvc;

    public class ContactController : BaseController
    {
        private readonly IContactService contactService;
        private readonly IEmailSender emailSender;

        public ContactController(
            IContactService contactService,
            IEmailSender emailSender)
        {
            this.contactService = contactService;
            this.emailSender = emailSender;
        }

        public IActionResult Index()
        {
            var model = this.contactService.Get<ContactViewModel>();

            return this.View(model);
        }
    }
}
