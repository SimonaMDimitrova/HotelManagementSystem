using HotelManagementSystem.Services.Data;
using HotelManagementSystem.Services.Messaging;
using HotelManagementSystem.Web.InputModels.Contact;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HotelManagementSystem.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SendEmailController : ControllerBase
    {
        private readonly IEmailSender emailSender;
        private readonly IContactService contactService;

        public SendEmailController(
            IEmailSender emailSender,
            IContactService contactService)
        {
            this.emailSender = emailSender;
            this.contactService = contactService;
        }

        [HttpPost]
        [IgnoreAntiforgeryToken]
        public async Task<ActionResult> Post(SendEmailInputModel input)
        {
            var hotelEmail = this.contactService.GetEmail();
            await this.emailSender.SendEmailAsync(
                input.From,
                input.FromName,
                hotelEmail,
                input.Subject,
                input.HtmlContent.ToString());

            return this.Ok();
        }
    }
}
