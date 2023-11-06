using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using WebAppMVC.Application.Interfaces;
using WebAppMVC.Application.ViewModel.UsersRoles;
using WebAppMVC.Domain.Interfaces.Users_Roles;
using WebAppMVC.Domain.Models;
using WebAppMVC.Domain.Models.Common;
using WebAppMVC.Infrastructure;

namespace WebAppMVC.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IRoleUserService _roleUserService;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserController(IRoleUserService roleUserService, SignInManager<ApplicationUser> signInManager)
        {
            _roleUserService = roleUserService;
            _signInManager = signInManager;
        }

        [Authorize(Roles = "Admin, SuperUser")]
        public IActionResult Index()
        {
            var users = _roleUserService.User.GetUsers();
            return View(users);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(string id)
        {
            var user = _roleUserService.User.GetUser(id);
            var roles = _roleUserService.Role.GetRoles();

            var userRoles = await _signInManager.UserManager.GetRolesAsync(user);

            var roleItems = roles.Select(role =>
                new SelectListItem(
                    role.Name,
                    role.Id,
                    userRoles.Any(ur => ur.Contains(role.Name)))).ToList();

            var vm = new EditUserForListVM()
            {
                User = user,
                Roles = roleItems
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> OnPostAsync(EditUserForListVM model)
        {
            var user = _roleUserService.User.GetUser(model.User.Id);
            if (user == null)
            {
                return NotFound();
            }

            var userRolesInDb = await _signInManager.UserManager.GetRolesAsync(user);

            var rolesToAdd = new List<string>();
            var rolesToDelete = new List<string>();

            foreach (var role in model.Roles)
            {
                var assignedInDb = userRolesInDb.FirstOrDefault(ur => ur == role.Text);
                if (role.Selected)
                {
                    if (assignedInDb == null)
                    {
                        rolesToAdd.Add(role.Text);
                    }
                }
                else
                {
                    if (assignedInDb != null)
                    {
                        rolesToDelete.Add(role.Text);
                    }
                }
            }

            if (rolesToAdd.Any())
            {
                await _signInManager.UserManager.AddToRolesAsync(user, rolesToAdd);
            }

            if (rolesToDelete.Any())
            {
                await _signInManager.UserManager.RemoveFromRolesAsync(user, rolesToDelete);
            }

            user.FirstName = model.User.FirstName;
            user.LastName = model.User.LastName;
            user.Email = model.User.Email;

            _roleUserService.User.UpdateUser(user);

            return RedirectToAction("Edit", new { id = user.Id });
        }

        [Authorize(Roles = "User")]
        public IActionResult UserViews()
        {
            return View();
        }

        [Authorize(Roles = "Admin, SuperUser")]
        public IActionResult SuperUserViews()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult AdminViews()
        {
            return View();
        }
    }
}