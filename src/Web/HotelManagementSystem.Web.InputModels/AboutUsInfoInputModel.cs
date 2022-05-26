namespace HotelManagementSystem.Web.InputModels
{
    using HotelManagementSystem.Data.Models;
    using HotelManagementSystem.Services.Mapping;
    using System.ComponentModel.DataAnnotations;

    public class AboutUsInfoInputModel : IMapFrom<AboutUsInfo>
    {
        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }
    }
}
