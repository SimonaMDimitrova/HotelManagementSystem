using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(HotelManagementSystem.Web.Areas.Identity.IdentityHostingStartup))]

namespace HotelManagementSystem.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}