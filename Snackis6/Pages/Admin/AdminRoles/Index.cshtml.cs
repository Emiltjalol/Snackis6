using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Snackis6.Pages.Admin.AdminRoles
{
    public class IndexModel : PageModel
    {
        public List<Areas.Identity.Data.Snackis6User> Users { get; set; }
        public List<IdentityRole> Roles { get; set; }

        [BindProperty(SupportsGet = true)]
        public string RoleName { get; set; }

        [BindProperty(SupportsGet = true)]
        public string AddUserId { get; set; }

        [BindProperty(SupportsGet = true)]
        public string RemoveUserId { get; set; }

        public bool IsUser { get; set; }

        public bool IsAdmin { get; set; }


        public readonly UserManager<Areas.Identity.Data.Snackis6User> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public IndexModel(RoleManager<IdentityRole> roleManager, UserManager<Areas.Identity.Data.Snackis6User> userManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task OnGetAsync()
        {
            Roles = await _roleManager.Roles.ToListAsync();
            Users = await _userManager.Users.ToListAsync();

            if (AddUserId != null)
            {
                var alterUser = await _userManager.FindByIdAsync(AddUserId);
                await _userManager.AddToRoleAsync(alterUser, RoleName);
            }

            if (RemoveUserId != null)
            {
                var alterUser = await _userManager.FindByIdAsync(RemoveUserId);
                await _userManager.RemoveFromRoleAsync(alterUser, RoleName);
            }


            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser != null)
            {
                IsUser = await _userManager.IsInRoleAsync(currentUser, "User");
                IsAdmin = await _userManager.IsInRoleAsync(currentUser, "Admin");
            }






        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (RoleName != null)
            {
                await CreateRole(RoleName);
            }
            return RedirectToPage("./Index");
        }

        public async Task CreateRole(string roleName)
        {
            bool roleExist = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                var Role = new IdentityRole
                {
                    Name = roleName
                };
                await _roleManager.CreateAsync(Role);
            }
        }
    }
}

