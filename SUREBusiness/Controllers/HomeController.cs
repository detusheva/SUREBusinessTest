using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SUREBusiness.Models;

namespace SUREBusiness.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ClaimsPrincipal currentUser = this.User;

            if (!currentUser.Identity.IsAuthenticated)
            {
                    return Redirect("Identity/Account/Login");
            }
            return RedirectToRoute(new { controller = "Note", action = "GetAllNotes"});
        }
    }

}