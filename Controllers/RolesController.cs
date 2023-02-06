using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [Authorize(Roles ="admin")]
    public class RolesController : Controller   //da controller 3l4an a3rd feeh kl el roles (w mynf34 8er el admin bs hwa ele yd5ol el controller da)
    {
        private RoleManager<IdentityRole> _rolemanager;
        public RolesController(RoleManager<IdentityRole> _rolemanager)
        {
            this._rolemanager = _rolemanager;
        }
        public IActionResult Index()
        {
            return View(_rolemanager.Roles.ToList());
        }
    }
}
