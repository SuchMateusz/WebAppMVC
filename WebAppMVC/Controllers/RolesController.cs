﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Text;
using WebAppMVC.Domain.Interfaces.Users_Roles;
using WebAppMVC.Domain.Models.Common;
using WebAppMVC.Infrastructure;

namespace WebAppMVC.Controllers
{
    [Authorize]
    public class RolesController : Controller
    {
        private readonly RoleManager<ApplicationRole> _roleManager;

        public RolesController(RoleManager<ApplicationRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [Authorize(Roles="User")]
        public IActionResult Index()
        {
            var roles = _roleManager.Roles.ToList();
            return View(roles);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, SuperUser")]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(ApplicationRole model)
        {
            model.Id = Guid.NewGuid().ToString();
            if (!_roleManager.RoleExistsAsync(model.Name).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(model).GetAwaiter().GetResult();
            }
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin, SuperUser")]
        public async Task<IActionResult> DeleteRole(ApplicationRole model)
        {
            var model2 = _roleManager.FindByNameAsync(model.Name).GetAwaiter().GetResult();
            _roleManager.DeleteAsync(model2).GetAwaiter().GetResult();
            return RedirectToAction("Index");
        }
    }
}