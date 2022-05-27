namespace HotelManagementSystem.Web.InputModels.Contact
{
    using System.ComponentModel.DataAnnotations;

    public class SendEmailInputModel
    {
        public string From { get; set; }

        public string FromName { get; set; }

        public string Subject { get; set; }

        public string HtmlContent { get; set; }
    }
}
