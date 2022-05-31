namespace HotelManagementSystem.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using HotelManagementSystem.Services.Data;
    using HotelManagementSystem.Web.InputModels.Area.Administration.ManageContact;
    using Microsoft.AspNetCore.Mvc;

    public class ManageContactController : AdministrationController
    {
        private readonly IContactService contactService;

        public ManageContactController(IContactService contactService)
        {
            this.contactService = contactService;
        }

        public IActionResult Index()
        {
            var model = this.contactService.Get<ContactInputModel>();
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(ContactInputModel input)
        {
            if (
                !this.IsHourValid(input.StartOfTheWorkingDayHour)
                || !this.IsMinuteValid(input.StartOfTheWorkingDayMinutes))
            {
                this.ModelState.AddModelError(nameof(input.StartOfTheWorkingDayHour), "Invalid time.");
            }

            if (
                !this.IsHourValid(input.EndOfTheWorkingDayHour)
                || !this.IsMinuteValid(input.EndOfTheWorkingDayMinutes))
            {
                this.ModelState.AddModelError(nameof(input.EndOfTheWorkingDayHour), "Invalid time.");
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.contactService.EditAsync(input);

            return this.View();
        }

        private bool IsHourValid(int hour)
        {
            var isValid = true;
            if (hour < 0 || hour > 24)
            {
                isValid = false;
            }

            return isValid;
        }

        private bool IsMinuteValid(int minutes)
        {
            var isValid = true;
            if (minutes < 0 || minutes > 60)
            {
                isValid = false;
            }

            return isValid;
        }
    }
}
