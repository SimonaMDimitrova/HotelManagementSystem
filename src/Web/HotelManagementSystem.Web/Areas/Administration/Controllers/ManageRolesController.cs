namespace HotelManagementSystem.Web.Areas.Administration.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using HotelManagementSystem.Data;
    using HotelManagementSystem.Data.Models;
    using HotelManagementSystem.Web.ViewModels.Area.Administration.ManageRoles;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class ManageRolesController : AdministrationController
    {
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext dbContext;

        public ManageRolesController(
            RoleManager<ApplicationRole> roleManager,
            UserManager<ApplicationUser> userManager,
            ApplicationDbContext dbContext)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var roles = this.roleManager.Roles;
            var viewModel = new RolesListViewModel
            {
                Roles = new List<RoleViewModel>(),
            };
            foreach (var role in roles)
            {
                var users = await this.userManager
                    .GetUsersInRoleAsync(role.Name);
                var usersToModel = users
                    .Select(x => new KeyValuePair<string, string>(x.Id, x.UserName))
                    .ToList();

                var roleViewModel = new RoleViewModel
                {
                    Id = role.Id,
                    Name = role.Name,
                    Users = usersToModel,
                };

                viewModel.Roles.Add(roleViewModel);
            }

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(string username, string role)
        {
            var user = this.userManager.Users.FirstOrDefault(x => x.UserName == username);
            if (user == null)
            {
                return this.RedirectToAction(nameof(this.Index));
            }

            await this.userManager.AddToRoleAsync(user, role);

            return this.RedirectToAction(nameof(this.Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var user = this.userManager.Users.FirstOrDefault(x => x.Id == id);
            var roles = await this.userManager.GetRolesAsync(user);
            var role = roles.FirstOrDefault();

            if (role == null)
            {
                return this.RedirectToAction(nameof(this.Index));
            }

            await this.userManager.RemoveFromRoleAsync(user, role);

            return this.RedirectToAction(nameof(this.Index));
        }
    }
}
